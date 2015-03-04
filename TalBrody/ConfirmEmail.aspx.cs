using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.DataLayer;

namespace TalBrody
{
    public partial class ConfirmEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var email = Request.Params.Get("email");
            var code = Request.Params.Get("code");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(code))
            {
                ActionResultLabel.Text = "Missing email or code";
                return;
            }

            var emailConfirmDal = new EmailConfirmDal();
            var confirmCode = emailConfirmDal.FindConfirmCode(code, email);
            if (confirmCode == null)
            {
                ActionResultLabel.Text = "Invalid email or code";
                return;
            }

            var userDal = new UserDal();
            var user = userDal.FindUserByEmail(email);
            if (user == null)
            {
                ActionResultLabel.Text = "Invalid email or code";
                return;
            }

            user.EmailConfirmed = true;
            userDal.UpdateUser(user);
            ActionResultLabel.Text = string.Format("Hi {0}, your email ({1}) is now confirmed", user.DisplayName, user.Email);

            // TODO redirect to share page on succesfull auth. remove code from DB. style the error page.
        }
    }
}