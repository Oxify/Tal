using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Common;
using TalBrody.Common.Enums;
using TalBrody.Entity;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{
    public partial class EditProject : System.Web.UI.Page
    {
        public int ProjectId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectId = int.Parse(Request["ProjectId"]);
            if(!IsPostBack)
            {
                InitParam();
            }
        }

        private void InitParam()
        {           
            PopulateFollwers(ProjectId);
        }

        private void PopulateFollwers(int ProjectId)
        {
            List<Follower> FollowerList = Followers.Get_Follower_by_Project(ProjectId);
            Rpt_Followers.DataSource = FollowerList;
            Rpt_Followers.DataBind();
        }

        protected void Rpt_Followers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                RepeaterItem item = e.Item;
                Follower folll = item.DataItem as Follower;

                Label LblId = e.Item.FindControl("LblId") as Label;
                if (LblId != null)
                    LblId.Text = folll.Id.ToString();

                Label LblProjectId = e.Item.FindControl("LblProjectId") as Label;
                if (LblProjectId != null)
                    LblProjectId.Text = folll.ProjectId.ToString();

                Label LblUserId = e.Item.FindControl("LblUserId") as Label;
                if (LblUserId != null)
                    LblUserId.Text = folll.UserId.ToString();

                Label LblCreateDate = e.Item.FindControl("LblCreateDate") as Label;
                if (LblCreateDate != null)
                    LblCreateDate.Text = folll.DateCreated.ToString("dd-MM-yyyy");

                Button BtnAddPermission = e.Item.FindControl("BtnAddPermission") as Button;
                if(BtnAddPermission != null)
                {
                   // check enable button for owner or admin
                    UserSession us = SessionUtil.GetUserSession();
                    if (us.PermissionList.Exists(o => o.PermisstionId == (int)PermisstionEnum.ProjectOwner || o.PermisstionId == (int)PermisstionEnum.Admin))
                        BtnAddPermission.Enabled = true;

                    List<Permission> pList = Permissions.Get_All_Permission_By_UserId(folll.UserId);
                    if (pList.Exists(o => o.ProjectId == ProjectId && o.PermisstionId == (int)PermisstionEnum.ProjectAdmin))
                    {                        
                        BtnAddPermission.Text = "Remove Permission";
                    }
                    else
                        BtnAddPermission.Text = "Add Permission";

                    BtnAddPermission.Attributes.Add("UserId", folll.UserId.ToString());
                }

            }
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int UserId = int.Parse(btn.Attributes["UserId"]);
            if(btn.Text == "Add Permission")
            {
                Permission per = new Permission();
                per.ProjectId = ProjectId;
                per.PermisstionId = (int)PermisstionEnum.ProjectAdmin;
                per.UserId = UserId;
                Permissions.InsertPermission(per);
            }
            else
            {
                List<Permission> Plist = Permissions.Get_All_Permission_By_UserId(UserId);
                Permissions.RemovePermission(Plist.Find(o => o.ProjectId == ProjectId && o.PermisstionId == (int)PermisstionEnum.ProjectAdmin).Id);
            }

            PopulateFollwers(ProjectId);                
        }
    }
}