using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fblogin
{
	public partial class LogIN : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
		{
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
	}
}