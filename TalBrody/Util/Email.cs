using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Razor;
using log4net;
using Mandrill;
using RazorEngine;
using RazorEngine.Templating;
using TalBrody.Entity;
using TalBrody.Logic;

namespace TalBrody.Util
{
    public class Email
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void SendRegistrationEmail(User user, string code)
        {
            var mandril = GetMandrill();
            var templateLocation = HttpContext.Current.Server.MapPath("~/Emails/RegistrationEmail.email");
            string template = System.IO.File.ReadAllText(templateLocation);

            var viewBag = new DynamicViewBag();
            viewBag.AddValue("BaseUrl", Global.BaseUrl);
            viewBag.AddValue("Code", code);
            string html = Engine.Razor.RunCompile(template, "registrationEmail", null, user, viewBag);
 
            var emailMessage = new EmailMessage
            {
                to = new List<EmailAddress> { new EmailAddress(user.Email, user.DisplayName) },
                from_email = "team@oxify.co",
                from_name = "Oxify",
                subject = "Welcome to Oxify",
                html = html
            };

            sendEmail(mandril, emailMessage);
        }

        private static void sendEmail(MandrillApi mandril, EmailMessage emailMessage)
        {
            log.Info("Sending email to " + emailMessage.to);
            mandril.SendMessage(emailMessage);
        }

        public static MandrillApi GetMandrill()
        {
            return new MandrillApi("J0BCtrmARKDInbkE0Xw3TQ");
        }
    }
}