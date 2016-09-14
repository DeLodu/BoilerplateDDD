using System;
using System.Net.Mail;
using Domain.DependencyContracts;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        public string Mailserver { get; set; }

        public void SentEmail()
        {
            //MailMessage mail = new MailMessage();
            //SmtpClient client = new SmtpClient();
            //client.Port = 25;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Host = "smtp.gmail.com";
            //mail.To = "user@hotmail.com"; // <-- this one
            //mail.From = "you@yourcompany.com";
            //mail.Subject = "this is a test email.";
            //mail.Body = "this is my test email body";
            //client.Send(mail);
        }

    }
}
