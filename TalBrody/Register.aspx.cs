using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using fblogin.DataLayer;
using fblogin.Entity;
using log4net;

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

            var user = new UserDal().FindUserByEmail(email.Value);
            if (user != null)
            {
                log.Info(String.Format("Existing user {0}/{1} tried to register", user.Id, user.Email));
                return;
            }

            new UserDal().CreateUser(email.Value, displayName.Value);
        }
    }

    public class RegisterEventArgs : EventArgs
    {
        public string email;
    }
}