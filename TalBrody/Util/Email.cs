using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mandrill;

namespace TalBrody.Util
{
    public class Email
    {
        public void SendRegistrationEmail(string email, string name)
        {
            var mandril = GetMandrill();
            var emailMessage = new EmailMessage
            {
                to = new List<EmailAddress> { new EmailAddress(email, name) },
                from_email = "team@oxify.co",
                from_name = "Oxify",
                subject = "Welcome to Oxify",
                html = "<p><b>Hello from Oxify!</b></p><p>Please click on <a href='#'>this link</a> to complete your registration.</p>"
            };

            mandril.SendMessage(emailMessage);
        }

        public static MandrillApi GetMandrill()
        {
            return new MandrillApi("J0BCtrmARKDInbkE0Xw3TQ");
        }
    }
}