using Microsoft.Extensions.Options;
using Projet.configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Projet.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender

        
    {

        public EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }



        public Task SendEmailAsync(string email, string subject, string message)
        {
            //return Task.CompletedTask;
            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string email, string subject, string message)
        {
            try
            {
                string toEmail = email;
                MailMessage mail = new MailMessage("mbenabde@hotmail.com", email, subject, message);
                //{
                //    From = new MailAddress("ECommerce.Inc", "Gerald Godin Team")
                //};
               

                //mail.Subject = "Personal Management System - " + subject;
                //mail.Body = message;
                //mail.IsBodyHtml = true;
                //mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential("mbenabde@hotmail.com", "ahmedamine2012");
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                //do something here
                Console.WriteLine(ex.Message);
            }
        }



    }
}
