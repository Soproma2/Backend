using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork36.Services
{
    internal class SMTPService
    {
        private string _email = "stepnika4@gmail.com";
        private string _password = "jawx suta olou blih";

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
