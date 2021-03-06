﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Razor;
using Castle.Windsor.Installer;
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
        private readonly IResourceResolver _resourceResolver;

        public Email(IResourceResolver resourceResolver)
        {
            _resourceResolver = resourceResolver;
        }

        public void SendPromoEmail(string userEamil,string DisplayName, string HtmlText,string FromEmail,string Subject,string FromName)
        {
            var mandril = GetMandrill();
           
            var emailMessage = new EmailMessage
            {
                to = new List<EmailAddress> { new EmailAddress(userEamil, DisplayName) },
                //new EmailAddress("NewUser@oxify.co", "New User Notification", "bcc")},
                from_email = FromEmail,
                from_name = FromName,

                subject = Subject,
                html = HtmlText
            };

            sendEmail(mandril, emailMessage);
        }

        public void SendRegistrationEmail(User user, string code)
        {
            var mandril = GetMandrill();
            string template = _resourceResolver.Resolve("Emails/RegistrationEmail.email");
            //string referUrl = Followers.GetReferLink(user.Id, 1);

            var viewBag = new DynamicViewBag();
            viewBag.AddValue("BaseUrl", Global.BaseUrl);
            viewBag.AddValue("Code", code);
            //viewBag.AddValue("Referal", referUrl);
            string html = Engine.Razor.RunCompile(template, "registrationEmail", null, user, viewBag);

            var emailMessage = new EmailMessage
            {
                to = new List<EmailAddress> { new EmailAddress(user.Email, user.DisplayName),
                new EmailAddress("NewUser@oxify.co", "New User Notification", "bcc")},
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