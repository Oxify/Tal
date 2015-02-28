using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Castle.Windsor;
using log4net;
using TalBrody.Common;
using TalBrody.Logic;
using TalBrody.Entity;

namespace TalBrody
{
    public partial class Ajax : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static WindsorContainer Container
        {
            get { return IOC.Container; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Response.IsRequestBeingRedirected)
            {
                return;
            }
            Response.Redirect("/", true);
            Context.ApplicationInstance.CompleteRequest();
        }

        public class RegisterResult
        {
            public int NextStep { get; set; } // 0 - login failure, 1 - registrating complete, 2 - email needed.


        }


        [WebMethod(EnableSession = true)]
        public static string LogInCheck(string UserName, string Password)
        {
            string result = "0";
            Users u = new Users();
            if (u.CheckUserPassword(UserName, Password))
            {
                SessionUtil.AddUserToSession(u.FindUserByEmail(UserName).Id);
                result = "1";
            }
            else
            {
                // LblMessage.Visible = true;
                // LblMessage.Text = "User name or Password is Incurect";
            }

            return result;

        }

        [ScriptMethod(UseHttpGet = true)]
        [WebMethod(EnableSession = false)]
        public static string Test(bool throwException)
        {
            // Pro tip: to call this, use
            // curl -H "Content-Type:application/json; charset=utf-8" http://tal.apphb.com/Ajax.aspx/Test?throwException=false
            log.Info("Test method called, throwException = " + throwException);
            if (throwException)
            {
                throw new Exception("Exception was requested and thus thrown");
            }

            return "All is well";
        }


        [WebMethod(EnableSession = true)]
        public static RegisterResult SocialRegister(string platform, string token)
        {
            RegisterResult result = new RegisterResult { NextStep = 0 };
            try
            {
                log.Info("SocialRegister hits");
                User user = null; 
                if (platform.ToUpper() == "FB")
                {
                    log.Info("SocialRegister hits 1");
                    var facebookAccess = Container.Resolve<FacebookAccess>();
                    log.Info("SocialRegister hits 2");
                    user = facebookAccess.RegisterUser(token);
                    SessionUtil.AddUserToSession(user.Id);
                    log.Info("SocialRegister hits 3");
                    if (user.Email != null && user.Email.IndexOf('@') != -1)
                        result.NextStep = 1;
                    else
                        result.NextStep = -1;
                    log.Info("SocialRegister hits 4");
                }
                if (user != null)
                {
                    log.Info("SocialRegister hits 5");
                    List<Follower> fololist = Followers.Get_Follower_by_Project(1);
                    if (!fololist.Exists(o => o.UserId == user.Id))
                    {
                        int UserRefId = 0;
                        if (HttpContext.Current.Session["UserRefId"] != null)
                        {
                            UserRefId = (int)HttpContext.Current.Session["UserRefId"];

                        }
                        Followers.Insert_Follwer(1, user.Id, UserRefId);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        public static int AutoLogin(string id)
        {
            int result = 0;
            try
            {
                int UserId = Users.SetUserContext(id);
                if (SessionUtil.AddUserToSession(UserId))
                {
                    result = 1;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex);

                throw;
            }
            return result;
        }

    }
}