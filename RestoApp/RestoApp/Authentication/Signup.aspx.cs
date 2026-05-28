using RestoApp.Helper;
using System;
using System.Data.SqlClient;

namespace RestoApp.Pages
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            string fullName = txtName.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text;

            // Input validation
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "All fields are required.";
                return;
            }

            if (password.Length < 6)
            {
                lblMessage.Text = "Password must be at least 6 characters.";
                return;
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            string token = Guid.NewGuid().ToString();
            DateTime expiry = DateTime.UtcNow.AddHours(24);

            try
            {
                using (SqlConnection con = DbHelper.GetConnection())
                {
                    string query = @"
                    INSERT INTO Users
                    (
                        FullName,
                        Email,
                        PasswordHash,
                        VerificationToken,
                        VerificationExpiry
                    )
                    VALUES
                    (
                        @FullName,
                        @Email,
                        @PasswordHash,
                        @VerificationToken,
                        @VerificationExpiry
                    )";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        cmd.Parameters.AddWithValue("@VerificationToken", token);
                        cmd.Parameters.AddWithValue("@VerificationExpiry", expiry);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                string verifyUrl = Request.Url.GetLeftPart(UriPartial.Authority) + "/Authentication/Verify.aspx?token=" + token;
                EmailService.SendEmail(email, "Verify Account", "Click here to verify:\n\n" + verifyUrl);

                lblMessage.Text = "Signup successful! Please check your email to verify your account.";
                lblMessage.CssClass = "text-success";
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Unique constraint violation — email already exists
                lblMessage.Text = "An account with this email already exists.";
            }
            catch (Exception)
            {
                lblMessage.Text = "An error occurred during signup. Please try again.";
            }
        }
    }
}
