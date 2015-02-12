using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Logic;

namespace TalBrody
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Response.IsRequestBeingRedirected)
            {
                return;
            }
            Response.Redirect("/", true);

        }


        [WebMethod(EnableSession = true)]
        public static int SocialRegister(string platform, string token)
        {
            int result = 0;
            try
            {
                if (platform.ToUpper() == "FB")
                {
                    var User = FacebookAccess.RegisterUser(token);
                    result = User.Id;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
    }
}