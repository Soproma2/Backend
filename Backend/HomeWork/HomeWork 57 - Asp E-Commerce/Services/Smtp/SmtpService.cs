using System.Net;
using System.Net.Mail;

namespace HomeWork_57___Asp_E_Commerce.Services.Smtp
{
    public class SmtpService
    {

            private string _email = "stepnika4@gmail.com";
            private string _password = "eloi ltyd llxg mswa";

            public void SendEmail(string subject, string email, string body)
            {
                var mail = new MailMessage();

                mail.From = new MailAddress(_email, "Soproma");
                mail.Subject = subject;
                mail.Body = body;
                mail.To.Add(email);
                mail.IsBodyHtml = false;

                var smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_email, _password)
                };

                smtp.Send(mail);
            }
    }
}
