using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace RestoApp.Helper
{
    public class EmailService
    {
        public static void SendEmail(string to, string subject, string body)
        {
            string fromEmail = ConfigurationManager.AppSettings["SmtpEmail"];
            string fromPassword = ConfigurationManager.AppSettings["SmtpPassword"];
            string smtpHost = ConfigurationManager.AppSettings["SmtpHost"] ?? "smtp.gmail.com";
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(smtpHost, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
