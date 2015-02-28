﻿using System;
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

        private void GetProjectId()
        {
            int ProjectId = -1;
            if (Request.QueryString["ProjectId"] != null)
                int.TryParse(Request.QueryString["ProjectId"], out ProjectId);
            HypEditProject.NavigateUrl = "EditProject.aspx?ProjectId=" + ProjectId;
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
                UserSession us = SessionUtil.GetUserSession();
                if (us != null)
                {
                    
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
            //return;
            var usession = SessionUtil.GetUserSession();
            string s = Request.PhysicalPath;
            if (usession != null)
            {
               
                if (usession.PermissionList.Exists(o => o.PermisstionId == (int)PermisstionEnum.Admin))
                {
                    HypSiteAdmin.Visible = true;
                    return;
                }
                else
                {
                    int ProjectId = usession.CurrentProjectId;                   
                    if (usession.PermissionList.Exists(o => o.ProjectId == ProjectId && (o.PermisstionId == (int)PermisstionEnum.ProjectAdmin || o.PermisstionId == (int)PermisstionEnum.ProjectOwner)))//  check if the user is projectadmin
                        HypEditProject.Visible = true;
                    
                }
            }
            else
            {
                if (s.IndexOf("EditProject.aspx", System.StringComparison.Ordinal) != -1 || s.IndexOf("SiteAdmin.aspx", System.StringComparison.Ordinal) != -1)
                {
                    const string message = "You do not have authorization to this page !!";
                    // TODO - do something secure here
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "EPG Edit", "<script language=\"javaScript\">" + "alert('" + message + "');  history.back();</script>");
                }
            }
        }
    }
}