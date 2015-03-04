using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.ClientServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using TalBrody.Common;
using TalBrody.Common.Enums;
using TalBrody.DataLayer;
using TalBrody.Entity;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{

    public partial class Oxify : System.Web.UI.MasterPage
    {
    //    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool LogInFlag = false;
        public string OxifyId = null;
        public string FcbkId = "";
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private WindsorContainer Container
        {
            get { return IOC.Container; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FcbkId = Global.FacebookId;
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
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public void btnClic(object sender, EventArgs e)
        {

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

        protected void BtnAddEmail_Click(object sender, EventArgs e)
        {
            UserSession useastion = SessionUtil.GetUserSession();
            if (useastion != null)
            {

                UserDal dal = Container.Resolve<UserDal>();
                User user = dal.FindUserByid(useastion.UserId);
                dal.UpdateUser(user);
                var code = Container.Resolve<Users>().GenerateUserRegistrationCode(user);
                IOC.GetInstance<Email>().SendRegistrationEmail(user, code);

            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            var emailStr = email.Value;
            if (string.IsNullOrEmpty(emailStr))
            {
                throw new Exception("Missing email on registration form");
            }

            string msg;
            var user = new UserDal().FindUserByEmail(emailStr);
            if (user != null)
            {
      //          msg = String.Format("Existing user {0}/{1} tried to register", user.Id, user.Email);
      //          log.Info(msg);
                msg = String.Format("כתובת האימייל " + user.Email + " כבר רשומה במערכת");
                LblRegistrationMessage.Text = msg;
                LblRegistrationMessage.Visible = true;
                return;
                //TODO handel duplicate registration 
            }

            var users = Container.Resolve<Users>();
            int UserRefId = 0;
            if (Session["UserRefId"] != null)
                UserRefId = (int)Session["UserRefId"];
            user = users.AddUser(emailStr, TxtPassword.Value, displayName.Value, UserRefId);

            SessionUtil.AddUserToSession(user.Id);
            Follower fol = Followers.GET_Follower_BY_UserId_and_project(user.Id, 1);
            if (fol == null)
            {
                Followers.Insert_Follwer(1, user.Id, UserRefId);
            }
        }
    }
}