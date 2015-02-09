using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor;
using Mandrill;
using RazorEngine;
using TalBrody.Entity;

namespace TalBrody.Util
{
    public class Email
    {
        public void SendRegistrationEmail(User user)
        {
            var mandril = GetMandrill();
            string template = @"<html>
<body>
<p>
<b>Hello @Model.DisplayName!</b>
</p>
<p>Please click on <a href='#'>this link</a> to complete your registration.</p>
</body>
</html>
";
            string html = Razor.Parse(template, user);

            var emailMessage = new EmailMessage
            {
                to = new List<EmailAddress> { new EmailAddress(user.Email, user.DisplayName) },
                from_email = "team@oxify.co",
                from_name = "Oxify",
                subject = "Welcome to Oxify",
                html = html
            };

            mandril.SendMessage(emailMessage);
        }

        public static MandrillApi GetMandrill()
        {
            return new MandrillApi("J0BCtrmARKDInbkE0Xw3TQ");
        }
    }
}