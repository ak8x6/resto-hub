using System;
using System.Web;
using System.Web.UI;
using RestoApp.Helper;
using System.Data.SqlClient;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;

namespace RestoApp.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both email and password.";
                return;
            }

            using (SqlConnection con = DbHelper.GetConnection())
            {
                string query = @"SELECT UserId, FullName, PasswordHash, IsEmailVerified, IsActive, Role
                                 FROM Users WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hash = reader["PasswordHash"].ToString();
                            bool valid = BCrypt.Net.BCrypt.Verify(password, hash);

                            if (valid)
                            {
                                bool verified = Convert.ToBoolean(reader["IsEmailVerified"]);
                                if (!verified)
                                {
                                    lblMessage.Text = "Please verify your email first.";
                                    return;
                                }

                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                if (!isActive)
                                {
                                    lblMessage.Text = "Your account has been deactivated. Please contact support.";
                                    return;
                                }

                                Session["UserId"] = reader["UserId"];
                                Session["UserName"] = reader["FullName"].ToString();
                                Session["UserRole"] = reader["Role"].ToString();

                                if (chkRememberMe.Checked)
                                {
                                    string userId = reader["UserId"].ToString();
                                    string token = CreateSecureToken(userId);
                                    HttpCookie authCookie = new HttpCookie("AuthToken");
                                    authCookie.Value = token;
                                    authCookie.Expires = DateTime.Now.AddDays(30);
                                    authCookie.HttpOnly = true;
                                    authCookie.Secure = true;
                                    Response.Cookies.Add(authCookie);
                                }

                                Response.Redirect("~/Default.aspx");
                            }
                            else
                            {
                                lblMessage.Text = "Invalid email or password.";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Invalid email or password.";
                        }
                    }
                }
            }
        }

        private string CreateSecureToken(string userId)
        {
            string timestamp = DateTime.UtcNow.Ticks.ToString();
            string data = userId + "|" + timestamp;
            string secret = System.Configuration.ConfigurationManager.ConnectionStrings["RestoDbConnection"].ConnectionString;
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                string signature = Convert.ToBase64String(hashBytes);
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(data + "|" + signature));
            }
        }

        protected void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
