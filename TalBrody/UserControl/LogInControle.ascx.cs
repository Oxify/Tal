using TalBrody.DataLayer;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody.UserControl
{
	public partial class LogInControle : System.Web.UI.UserControl
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected void Page_Load(object sender, EventArgs e)
		{
			log.Info("Page_Load for LogIN.aspx.cs");
		}

		protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
		{
			log.Info(String.Format("Gotting authenticate request (%s, %s)", Login1.UserName, Login1.Password));

			try
			{
				if (Login1.UserName == "Magic" && Login1.Password == "Card")
				{
					Session.Add("Authenticated", true);
					Response.Redirect("ProjectData.aspx");
				}
				else
				{
					e.Authenticated = false;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		protected void loginButton_Click(object sender, EventArgs e)
		{
			log.Info("loginButton_Click acccessed");
			throw new NotImplementedException();
		}

		protected void openidValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			throw new NotImplementedException();
		}

		private bool IsValidEmail(string email)
		{
			// TODO - replace with System.ComponentModel.DataAnnotations.EmailAddressAttribute
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}

		public bool RegisterOrLogin(string email)
		{
			if (!IsValidEmail(email))
			{
				return false;
				//	success = false,
				//	error = "Invalid email"

			}
			var user = new UserDal().FindUserByEmail(email);
			if (user != null)
			{
				log.Info(String.Format("Existing user {0}/{1} tried to register", user.Id, user.Email));
				return true;
				//	redirectTo = "Login/Login"

			}

			//users.CreateUser(email);
			return true;
			//redirectTo = "Login/CreateAccount?email=" + email // TODO - fill this in from the user's registration state

		}

		public int Register(string email, string password)
		{
			if (!IsValidEmail(email))
			{
				return 0;
			}

			if (!IsValidPassword(password))
			{
				return 0;
			}

            if (Users.FindUserByEmail(email) != null)
			{
				return 0;
			}

            return Users.CreateUser(email, password); 
		}

		public string CreateAccount(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				return "Missing email parameter";
			}



			return "ToDo1";


		}

	   

		public bool TryLogin(string email, string password)
		{
			return Users.CheckUserPassword(email, password);
			//{
			//	return Json(new { success = false, error = "Wrong email or password" });
			//}			
		}

		bool IsValidPassword(string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				return false;
			}

			if (password.Length < 4)
			{
				return false;
			}

			return true;
		}
	}
}