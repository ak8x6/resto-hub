using System;
using System.Data.SqlClient;
using RestoApp.Helper;

namespace RestoApp.Pages
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email)) return;

            string resetToken = Guid.NewGuid().ToString();
            DateTime expiry = DateTime.UtcNow.AddHours(1);

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "UPDATE Users SET ResetToken = @Token, ResetTokenExpiry = @Expiry WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Token", resetToken);
                    cmd.Parameters.AddWithValue("@Expiry", expiry);
                    cmd.Parameters.AddWithValue("@Email", email);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string resetUrl = Request.Url.GetLeftPart(UriPartial.Authority) + "/Authentication/ResetPassword.aspx?token=" + resetToken;
                        string body = "Click the following link to reset your password: " + resetUrl;
                        EmailService.SendEmail(email, "Password Reset", body);
                    }

                    // Always show the same message to prevent email enumeration
                    lblMessage.Text = "If this email exists, a password reset link has been sent.";
                }
            }
        }
    }
}
