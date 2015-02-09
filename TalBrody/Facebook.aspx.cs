using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web;
using DotNetOpenAuth.ApplicationBlock;
using DotNetOpenAuth.ApplicationBlock.Facebook;
using DotNetOpenAuth.OAuth2;
using log4net;
using NUnit.Framework;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{

    public partial class Facebook : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly FacebookClient client = new FacebookClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["facebookAppID"],
            ClientCredentialApplicator = ClientCredentialApplicator.PostParameter(ConfigurationManager.AppSettings["facebookAppSecret"]),
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            IAuthorizationState authorization = client.ProcessUserAuthorization();
            if (authorization == null)
            {
                // Kick off authorization request
                var scopes = new List<string> { "user_friends", "email" };
                client.RequestUserAuthorization(scopes);

            }
            else
            {

                if (authorization.AccessToken == null)
                {
                    this.nameLabel.Text = HttpUtility.HtmlEncode("User did not authorize!");

                }
                else
                {
                    var details = FacebookAccess.GetUserData(authorization.AccessToken);

                    this.nameLabel.Text = HttpUtility.HtmlEncode(details.Graph.Name + ", your email is: " + details.Graph.EMail);




                }
            }
        }
    }
}