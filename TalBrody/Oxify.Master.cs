using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Common.Enums;
using TalBrody.Util;

namespace TalBrody
{
    public partial class Oxify : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermissions();
            }
        }

        private void CheckPermissions()
        {
            // TODO make this relevant. right now it only kicks everyone out unless it's the cover page
            return;

            string s = Request.FilePath;
            if (Session["Usession"] != null)
            {
                var usession = (UserSession) Session["Usession"];
                if(usession.PermissionList.Exists(o=> o.PermisstionName == PermisstionEnum.Admin.ToString()))
                    return;
                else
                {
                    //TODO ziv  add permission Ability 
                }
            }
            else
            {
                if (s.IndexOf("Cover.aspx", System.StringComparison.Ordinal) == -1)
                {
                    const string message = "You do not have authorization to this page !!";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "EPG Edit", "<script language=\"javaScript\">" + "alert('" + message + "');  history.back();</script>");
                }
            }
        }
    }
}