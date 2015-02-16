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
            RegisterResult result = new RegisterResult {NextStep = 0};
            try
            {
                if (platform.ToUpper() == "FB")
                {
                    var User = FacebookAccess.RegisterUser(token);
                    CommonFunction.AddUserToSession(User.Id);
                    result.NextStep = 1;
                    
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
                CommonFunction.AddUserToSession(UserId);
                result = 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

    }
}