using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mandrill;
using TalBrody.Common;
using TalBrody.DataLayer;
using TalBrody.Entity;
using log4net;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{

    public partial class Register : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            log.Info("Page_Load for Register.aspx.cs");
        }

        protected void registerButton_Click(object sender, EventArgs eventArgs)
        {
            if (string.IsNullOrEmpty(email.Value))
            {
                throw new Exception("Missing email on registration form");
            }

            string msg;
            var user = new UserDal().FindUserByEmail(email.Value);
            if (user != null)
            {
                msg = String.Format("Existing user {0}/{1} tried to register", user.Id, user.Email);
                log.Info(msg);
                registerResultLabel.Text = msg;
                return;
                //TODO handel Dubale registration 
            }

            Users.CreateUser(email.Value, TxtPassword.Value);
            msg = string.Format("Created new user (email, name) = ({0}, {1})", email.Value, displayName.Value);
            registerResultLabel.Text = msg;
            log.Info(msg);

            user = new UserDal().FindUserByEmail(email.Value);
            user.DisplayName = displayName.Value;
            Users.UpdateUser(user);
            var code = Users.GenerateUserRegistrationCode(user);
            new Email().SendRegistrationEmail(user, code);
            CommonFunction.AddUserToSession(user.Id);
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = '../Share.aspx'; </script>");

        }


    }

    public class RegisterEventArgs : EventArgs
    {
        public string email;
    }
}