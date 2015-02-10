using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.DataLayer;

namespace TalBrody
{
    public partial class Share : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO - Get Logged In User
            var user = new UserDal().FindUserByid(1);

            ShareUrl = string.Format("{0}?r={1}", Global.BaseUrl, user.ReferralCode);
            FacebookShareUrl = "https://www.facebook.com/sharer/sharer.php?app_id=1423139441310101&u=" + HttpUtility.UrlEncode(ShareUrl) + "&display=popup&ref=plugin";
            TwitterShareUrl = "https://twitter.com/share?url=" + HttpUtility.UrlEncode(ShareUrl);
        }

        public string ShareUrl;
        public string FacebookShareUrl;
        public string TwitterShareUrl;
    }
}