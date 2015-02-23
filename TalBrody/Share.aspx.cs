using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.DataLayer;
using TalBrody.Entity;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{
    public class UrlBuilder
    {
        public string GetBaseUrl()
        {
            // var siteUrl = ConfigurationManager.AppSettings.Get("SiteUrl");

            return Global.OnAppHarbor
                ? "http://oxify.co/"
                : "http://localhost:61400/";

        }

        public string GetProjectUrl()
        {
            string projectId = "mfp17"; // TODO
            return GetBaseUrl() + "p/mfp17/toys";
        }
    }

    public partial class Share : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO - Get Logged In User
            //var user = new UserDal().FindUserByid(1);

            UserSession Usession = (UserSession)Session["Usession"];
            if (Usession == null)
            {
                // No session, redirect to homepage
                // TODO
                
            }
            ShareUrl = string.Format("{0}?r={1}", IOC.GetInstance<UrlBuilder>().GetProjectUrl(), Usession.UserId);
            FacebookShareUrl = "https://www.facebook.com/sharer/sharer.php?u=" + HttpUtility.UrlEncode(ShareUrl) + "&display=popup&ref=plugin";
            TwitterShareUrl = "https://twitter.com/share?url=" + HttpUtility.UrlEncode(ShareUrl);
        }

        public string ShareUrl;
        public string FacebookShareUrl;
        public string TwitterShareUrl;
    }
}