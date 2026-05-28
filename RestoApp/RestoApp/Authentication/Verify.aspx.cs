using RestoApp.Helper;
using System;
using System.Data.SqlClient;

namespace RestoApp.Pages
{
    public partial class Verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string token = Request.QueryString["token"];

                if (token == null)
                {
                    lblMessage.Text = "Invalid token.";
                    return;
                }

                using (SqlConnection con = DbHelper.GetConnection())
                {
                    string query = @"
                    SELECT * FROM Users
                    WHERE VerificationToken=@token";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@token", token);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime expiry = Convert.ToDateTime(reader["VerificationExpiry"]);

                                if (expiry < DateTime.UtcNow)
                                {
                                    lblMessage.Text = "Token expired.";
                                    return;
                                }

                                reader.Close();

                                string update = @"
                                UPDATE Users
                                SET
                                    IsEmailVerified = 1,
                                    VerificationToken = NULL
                                WHERE VerificationToken=@token";

                                using (SqlCommand updateCmd = new SqlCommand(update, con))
                                {
                                    updateCmd.Parameters.AddWithValue("@token", token);
                                    updateCmd.ExecuteNonQuery();
                                }

                                lblMessage.Text = "Email verified successfully! You can now login.";
                                Response.Redirect("~/Authentication/Login.aspx");
                            }
                            else
                            {
                                lblMessage.Text = "Invalid token.";
                            }
                        }
                    }
                }
            }
        }
    }
}
