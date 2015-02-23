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
    public partial class Share : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO - Get Logged In User
            //var user = new UserDal().FindUserByid(1);

            UserSession Usession = (UserSession)Session["Usession"];

            List<Follower> followerlist = Followers.Get_Follower_by_Project(Usession.CurrentProjectId);

            string FollowerGuid = followerlist.Find(o => o.UserId == Usession.UserId).FollowerGuid;


            ShareUrl = string.Format("{0}?r={1}", ConfigurationManager.AppSettings.Get("SiteUrl"), FollowerGuid);
            FacebookShareUrl = "https://www.facebook.com/sharer/sharer.php?app_id=1423139441310101&u=" + HttpUtility.UrlEncode(ShareUrl) + "&display=popup&ref=plugin";
            TwitterShareUrl = "https://twitter.com/share?url=" + HttpUtility.UrlEncode(ShareUrl);
        }

        public string ShareUrl;
        public string FacebookShareUrl;
        public string TwitterShareUrl;
    }
}