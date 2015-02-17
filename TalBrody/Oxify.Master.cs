using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Common;
using TalBrody.Common.Enums;
using TalBrody.Entity;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{

    public partial class Oxify : System.Web.UI.MasterPage
    {
        public bool LogInFlag = false;
        public string OxifyId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LogInFlag = CheckLogIn();
            if (!IsPostBack)
            {
                CheckPermissions();
            }
        }

        public void DoLOgOut()
        {
            Session.Remove("Usession");
        }

        private bool CheckLogIn()
        {
            bool result = false;
            try
            {
                if (Session["Usession"] != null)
                {
                    UserSession us = (UserSession)Session["Usession"];
                    result = true;
                    OxifyId = Users.GetUserContext(us.UserId);
                    LblUserName.Text = "Hello: " + us.UserName;
                }
            }
            catch (Exception )
            {

                throw;
            }
            return result;
        }

        private void CheckPermissions()
        {
            // TODO make this relevant. right now it only kicks everyone out unless it's the cover page
            return;

            string s = Request.FilePath;
            if (Session["Usession"] != null)
            {
                var usession = (UserSession)Session["Usession"];
                if (usession.PermissionList.Exists(o => o.PermisstionName == PermisstionEnum.Admin.ToString()))
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
                    // TODO - do something secure here
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "EPG Edit", "<script language=\"javaScript\">" + "alert('" + message + "');  history.back();</script>");
                }
            }
        }
    }
}