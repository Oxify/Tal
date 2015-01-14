using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Entity;
using TalBrody.Logic;

namespace TalBrody
{
	public partial class Index : System.Web.UI.Page
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
			List<Project> ProjectList = Projects.GetAllProject();
			rpt_Project.DataSource = ProjectList;
			rpt_Project.DataBind();
		}

		protected void rpt_Project_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
				{
					RepeaterItem item = e.Item;
					Project Pro = item.DataItem as Project;

					HyperLink HypProjectLink = e.Item.FindControl("HypProjectLink") as HyperLink;
					if (HypProjectLink != null)
						HypProjectLink.NavigateUrl = Pro.LinkUrl;

					Label LblProjectName = e.Item.FindControl("LblProjectName") as Label;
					if (LblProjectName != null)
						LblProjectName.Text = Pro.DisplayName;

					Label lblDescription = e.Item.FindControl("lblDescription") as Label;
					if (lblDescription != null)
						lblDescription.Text = Pro.Description;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}


	}
}