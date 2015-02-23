using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{
	public partial class Cover : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				InitParam();
                AddFollowerCount();
			}

		    ChecktoHideDiv();
		}

        private void AddFollowerCount()
        {
            try
            {
                if(Request.QueryString["r"] != null)
                {
                    Followers.AddFollowerCount(Request.QueryString["r"]);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

	    private void ChecktoHideDiv()
	    {
	        if (Session["Usession"] != null)
	        {
                
                firstpage.Visible = false;
                if (Request.QueryString["ProjectId"] != null)
                {
                    int ProjectId = int.Parse(Request.QueryString["ProjectId"]);
                    UserSession u = (UserSession)Session["Usession"];
                    u.CurrentProjectId = ProjectId;
                }
	        }
	    }

		
		
		private void InitParam()
		{
//			LblTitle.Style.Add("font-size", "30px");
		}
	}
}