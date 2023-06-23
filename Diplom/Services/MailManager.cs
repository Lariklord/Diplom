using Diplom;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Diplom
{
    class MailManager : IEmailSender
    {
        private readonly string BaseEmail;
        private readonly string BasePassword;

        private SmtpClient SmtpClient;

        public MailManager()
        {

            BaseEmail = "groshikstore@mail.ru";
            BasePassword = "ycNnbZvbVKzV570C2M03";

            SmtpClient = new SmtpClient("smtp.mail.ru", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(BaseEmail, BasePassword),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(BaseEmail),
                Body = htmlMessage,
                Subject = subject,
                IsBodyHtml = true

            };

            mailMessage.To.Add(email);
            await SmtpClient.SendMailAsync(mailMessage);
        }
    }
}
