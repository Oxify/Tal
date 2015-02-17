using TalBrody.Entity;
using TalBrody.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TalBrody
{
	public partial class ProjectData : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!CeckPermosion())
			{
				Response.Redirect("LogIN.aspx");
			}
			if (!IsPostBack)
			{
				
				InitParam();
			}
		}

		private bool CeckPermosion()
		{
			try
			{
				return bool.Parse(Session["Authenticated"].ToString());
			}
			catch (Exception)
			{

				return false;
			}


		}

		private void InitParam()
		{
			PopulateConsept();
			populateFollowers();
		}

		private void populateFollowers()
		{
			try
			{
				
			}
			catch (Exception)
			{
				
				throw;
			}
		}

		private void PopulateConsept()
		{
			try
			{
				
			}
			catch (Exception)
			{
				
				throw;
			}
		}
	}
}