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
using log4net;
using TalBrody.Common;
using TalBrody.Logic;

namespace TalBrody
{
    public partial class Ajax : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                if (platform.ToUpper() == "FB")
                {
                    var User = FacebookAccess.RegisterUser(token);
                    CommonFunction.AddUserToSession(User.Id);
                    if (User.Email != null && User.Email.IndexOf('@') != -1)
                        result.NextStep = 1;
                    else
                        result.NextStep = -1;
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
                CommonFunction.AddUserToSession(UserId);
                result = 1;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

    }
}