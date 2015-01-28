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
				LblSupporters.Text = Followers.Get_NmberOf_Follwers_By_Project(1).ToString();
				PopulatePerks(1);
			}
			catch (Exception)
			{

				throw;
			}

		}

		private void PopulatePerks(int ProjectId)
		{
			try
			{
				List<Perks> perkslist = Perkses.GetAllPerksByProjectId(1);
				rpt_perks.DataSource = perkslist;
				rpt_perks.DataBind();
			}
			catch (Exception)
			{
				
				throw;
			}
		}

		protected void rpt_perks_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{

				RepeaterItem item = e.Item;
				Perks perk = item.DataItem as Perks;

				Label lblPerkId = e.Item.FindControl("lblPerkId") as Label;
				if (lblPerkId != null)
					lblPerkId.Text = perk.CounterId.ToString();

				Label lblDescription = e.Item.FindControl("lblDescription") as Label;
				if (lblDescription != null)
					lblDescription.Text = perk.Description;

				Label lblTitle = e.Item.FindControl("lblTitle") as Label;
				if (lblTitle != null)
					lblTitle.Text = perk.Title;

				Label lblCost = e.Item.FindControl("lblCost") as Label;
				if (lblCost != null)
					lblCost.Text = perk.Cost.ToString();

			}
		}
	}
}