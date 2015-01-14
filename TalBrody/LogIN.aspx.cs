using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace fblogin
{
	public partial class LogIN : System.Web.UI.Page
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
					Response.Redirect("ConseptData.aspx");
				}
				else
				{
					e.Authenticated = false;
				}
			}
			catch (Exception ex)
			{
				
				throw ex;
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
	}
}