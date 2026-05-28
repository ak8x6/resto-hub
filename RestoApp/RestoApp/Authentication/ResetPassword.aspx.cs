using System;
using System.Data.SqlClient;
using RestoApp.Helper;

namespace RestoApp.Pages
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["token"]))
            {
                lblMessage.Text = "Invalid or missing token!";
                btnReset.Enabled = false;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string token = Request.QueryString["token"];
            string newPassword = txtNewPassword.Text;

            if (string.IsNullOrEmpty(newPassword))
            {
                lblMessage.Text = "Please enter a new password.";
                return;
            }

            string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = @"UPDATE Users 
                                 SET PasswordHash = @PasswordHash, 
                                     ResetToken = NULL, 
                                     ResetTokenExpiry = NULL 
                                 WHERE ResetToken = @Token 
                                 AND ResetTokenExpiry > GETUTCDATE()";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PasswordHash", newPasswordHash);
                    cmd.Parameters.AddWithValue("@Token", token);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Password has been successfully changed! You can now login.";
                        lblMessage.CssClass = "text-success";
                        btnReset.Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "Invalid or expired reset token.";
                    }
                }
            }
        }
    }
}
