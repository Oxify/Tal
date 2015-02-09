using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor;
using Mandrill;
using RazorEngine;
using RazorEngine.Templating;
using TalBrody.Entity;
using TalBrody.Logic;

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
@{
    var url = ViewBag.BaseUrl + ""ConfirmEmail?email="" + Model.Email + @Raw(""&code="") + ViewBag.Code;
}

<p>Please click on <a href='@url'>this link</a> to complete your registration.</p>
</body>
</html>
";
            var viewBag = new DynamicViewBag();
            viewBag.AddValue("BaseUrl", GetBaseUrl());
            var code = Users.GenerateUserRegistrationCode(user);
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

            mandril.SendMessage(emailMessage);
        }

        private static string GetBaseUrl()
        {
            return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                   HttpContext.Current.Request.ApplicationPath;
            // return "http://localhost:61400/";
        }

        public static MandrillApi GetMandrill()
        {
            return new MandrillApi("J0BCtrmARKDInbkE0Xw3TQ");
        }
    }
}