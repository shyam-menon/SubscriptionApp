using System;
using System.Text;

namespace SubscriptionApp.API.Infrastructure.Email
{
    public class TextLoggingEmailService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {
            StringBuilder email = new StringBuilder();

            email.AppendLine(String.Format("To: {0}", to));
            email.AppendLine(String.Format("From: {0}", from));
            email.AppendLine(String.Format("Subject: {0}", subject));
            email.AppendLine(String.Format("Body: {0}", body));

            System.Diagnostics.Debug.WriteLine(email.ToString());           
            
        }
    }
}