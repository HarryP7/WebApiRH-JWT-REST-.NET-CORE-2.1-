using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRH.Models.Services
{
    public class EmailSender : IEmailSender, IDisposable
    {
        private const string From = "grishkamartov@gmail.com";
        private readonly SmtpClient smtp;

        public EmailSender(SmtpClient smtp)
        {
            this.smtp = smtp;
        }

        public void Send(string message, string to)
        {
            var addressFrom = new MailAddress(From);
            var addressTo = new MailAddress(to);

            var mailMessages = new MailMessage(addressFrom.ToString(), addressTo.ToString());
            mailMessages.Subject = "Управляй своим домом";
            mailMessages.Body = "Ваш код подтверждения для изменения пароля: "+message;
            mailMessages.IsBodyHtml = false;
            Send(mailMessages);
        }

        private void Send(MailMessage msg)
        {
            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Dispose()
        {
            smtp.Dispose();
        }
    }
}