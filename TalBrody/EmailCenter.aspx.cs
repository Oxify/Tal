using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Entity;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{
    public partial class EmailCenter : System.Web.UI.Page
    {
        int ProjectId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitFunc();
            }
            else
            {
                if (txtSystemEmailInfoFooter != null && !string.IsNullOrWhiteSpace(txtSystemEmailInfoFooter.Value))
                {
                    txtSystemEmailInfoFooter.Value = HttpUtility.HtmlDecode(txtSystemEmailInfoFooter.Value);
                }

            }
        }

        private void InitFunc()
        {
            PopulateFollwers(ProjectId);
           
        }

        private void PopulateFollwers(int ProjectId)
        {
            List<Follower> FollowerList = Followers.Get_Follower_by_Project(ProjectId);
            Rpt_Followers.DataSource = FollowerList;
            Rpt_Followers.DataBind();
        }

        private void SendPromoMail()
        {
            string EmailContent = txtSystemEmailInfoFooter.Value.Trim();
            Users users = new Users();
            Email _email = IOC.GetInstance<Email>();
            string Subject = TxtSubject.Text;
            string FromEamil = TxtEmailFrom.Text;
            string FromName = TxtFromName.Text;
            foreach (RepeaterItem item in Rpt_Followers.Items)
            {
                CheckBox CBSendEmail = item.FindControl("CBSendEmail") as CheckBox;
                if (CBSendEmail != null && CBSendEmail.Checked)
                {
                    int UserId = int.Parse(CBSendEmail.Attributes["UserId"]);
                    User user = users.FindUserByUserId(UserId);
                    _email.SendPromoEmail(user, EmailContent, FromEamil, Subject, FromName);
                }
            }
        }

        protected void Rpt_Followers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
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

                CheckBox CBSendEmail = e.Item.FindControl("CBSendEmail") as CheckBox;
                if (CBSendEmail != null)
                {
                    CBSendEmail.Attributes.Add("UserId", folll.UserId.ToString());
                }
            }
        }

        protected void BtnSendEmail_Click(object sender, EventArgs e)
        {
            SendPromoMail();
        }
    }
}