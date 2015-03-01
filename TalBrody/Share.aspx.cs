using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Common;
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
            string projectId = "m1fj"; // TODO
            return GetBaseUrl() + "p/m1fj/toys";
		}
	}

	public partial class Share : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

            UserSession Usession = SessionUtil.GetUserSession();
			if (Usession != null)
			{
                Follower fol = Followers.GET_Follower_BY_UserId_and_project(Usession.UserId, 1);
			    string ProjectName = " עודני כאן - ספר נוסטלגי על בית הבראה לצעצועים ";
				ShareUrl = string.Format("{0}?r={1}", IOC.GetInstance<UrlBuilder>().GetProjectUrl(), fol.FollowerGuid);
			    var ShareUrlEncoded = HttpUtility.UrlEncode(ShareUrl);
				FacebookShareUrl = "https://www.facebook.com/sharer/sharer.php?u=" + HttpUtility.UrlEncode(ShareUrl) + "&display=popup&ref=plugin";
				TwitterShareUrl = "https://twitter.com/share?url=" + HttpUtility.UrlEncode(ShareUrl);
                WhatsappUrl = "whatsapp://send?text=" + ProjectName + ShareUrlEncoded;
			}
		}

		public string ShareUrl;
		public string FacebookShareUrl;
		public string TwitterShareUrl;
	    public string WhatsappUrl;
	}
}