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
    public partial class AdminDeashBord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                InitParam();
            }
        }

        private void InitParam()
        {
            List<ProjectEntity> prokectList = Projects.GetAllProject();
            Rpt_Project.DataSource = prokectList;
            Rpt_Project.DataBind();
        }

        protected void Rpt_Project_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
                {
                    RepeaterItem item = e.Item;
                    ProjectEntity pro = item.DataItem as ProjectEntity;

                    Label LblCounterId = e.Item.FindControl("LblCounterId") as Label;
                    if (LblCounterId != null)
                        LblCounterId.Text = pro.ProjectCount.ToString();

                    Label LblFollowers = e.Item.FindControl("LblFollowers") as Label;
                    if (LblFollowers != null)
                        LblFollowers.Text = Followers.Get_Follower_by_Project(pro.id).Count.ToString();

                    HyperLink HypProjectLink = e.Item.FindControl("HypProjectLink") as HyperLink;
                    if (HypProjectLink != null)
                        HypProjectLink.Text = pro.LinkUrl;

                    HyperLink HypEditPojectLink = e.Item.FindControl("HypEditPojectLink") as HyperLink;
                    if (HypEditPojectLink != null)
                        HypEditPojectLink.NavigateUrl = Page.GetRouteUrl("Edit", new { ProjectId = pro.id.ToString() });
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}