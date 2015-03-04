﻿using System;
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
        public static RegisterResult SocialRegister(string platform, string token, string email)
        {
            RegisterResult result = new RegisterResult { NextStep = 0 };
            try
            {

                User user = null;
                if (platform.ToUpper() == "FB")
                {
                    var facebookAccess = Container.Resolve<FacebookAccess>();
                    user = facebookAccess.RegisterUser(token, email);

                    if (user.Email != null && user.Email.IndexOf('@') != -1)
                    {
                        SessionUtil.AddUserToSession(user.Id);
                        result.NextStep = 1;

                    }
                    else
                    {
                        result.NextStep = -1;
                        return result;
                    }
                }
                if (user != null)
                {
                    Follower fol = Followers.GET_Follower_BY_UserId_and_project(user.Id, 1);
                    if (fol == null)
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

                throw;
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

        [WebMethod(EnableSession = true)]
        public static int SocialLogin(string platform, string token)
        {
            int result = 0;
            try
            {
                User user = null;
                if (platform.ToUpper() == "FB")
                {
                    var facebookAccess = Container.Resolve<FacebookAccess>();
                    user = facebookAccess.LoginUser(token);

                    if (user != null)
                    {
                        SessionUtil.AddUserToSession(user.Id);
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }


    }
}