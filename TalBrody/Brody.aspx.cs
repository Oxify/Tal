using fblogin.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fblogin
{
	public partial class Brody : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				InitParam();
			}
		}

		private void InitParam()
		{
			try
			{
				LblSupporters.Text = Users.Get_NmberOf_Follwers_By_Project(1).ToString();
			}
			catch (Exception)
			{

				throw;
			}

		}

		protected void rpt_perks_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{

		}
	}
}