using Oxify.Entity;
using Oxify.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Oxify
{
	public partial class ConseptData : System.Web.UI.Page
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
			catch (Exception ex)
			{
				
				throw ex;
			}
		}

		private void PopulateConsept()
		{
			try
			{
				
			}
			catch (Exception ex)
			{
				
				throw ex;
			}
		}
	}
}