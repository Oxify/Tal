using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Castle.Windsor;
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

        private WindsorContainer Container
        {
            get { return IOC.Container; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            log.Info("Page_Load for Register.aspx.cs");
        }

        protected void registerButton_Click(object sender, EventArgs eventArgs)
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
                msg = String.Format("Existing user {0}/{1} tried to register", user.Id, user.Email);
                log.Info(msg);
                registerResultLabel.Text = msg;
                return;
                //TODO handel duplicate registration 
            }

            var users = Container.Resolve<Users>();
            int UserRefId = 0;
            if (Session["UserRefId"] != null)
                UserRefId = (int)Session["UserRefId"];
            user = users.AddUser(emailStr, TxtPassword.Value, displayName.Value, UserRefId);

            // TODO Remove (this is properly logged elsewhere)
            registerResultLabel.Text = string.Format("Created new user (email, name) = ({0}, {1})", emailStr, displayName);

            SessionUtil.AddUserToSession(user.Id);
            Follower fol = Followers.GET_Follower_BY_UserId_and_project(user.Id, 1);
            if (fol == null)
            {
                Followers.Insert_Follwer(2, user.Id, UserRefId);
            }
            // TODO What does this do? Document please
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = '../Share.aspx'; </script>");
        }

        protected void BtnAddEmail_Click(object sender, EventArgs e)
        {
            UserSession useastion = SessionUtil.GetUserSession();
            if (useastion != null)
            {

                UserDal dal = Container.Resolve<UserDal>();
                User user = dal.FindUserByid(useastion.UserId);
                user.Email = txtEmail.Value;
                dal.UpdateUser(user);
                var code = Container.Resolve<Users>().GenerateUserRegistrationCode(user);
                IOC.GetInstance<Email>().SendRegistrationEmail(user, code);
                ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = '/Share.aspx'; </script>");
            }
        }


    }

    public class RegisterEventArgs : EventArgs
    {
        public string email;
    }
}