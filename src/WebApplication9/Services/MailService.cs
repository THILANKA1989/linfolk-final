using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string to, string from, string body, string subject)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Contact Linfolk", "gajaba88@gmail.com"));
                message.To.Add(new MailboxAddress("Linfolk", to));
                message.Subject = subject;
                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("gajaba88@gmail.com", "pathfinder1989");
                    // Note: since we don't have an OAuth2 token, disable 	// the XOAUTH2 authentication mechanism.     client.Authenticate("anuraj.p@example.com", "password");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
