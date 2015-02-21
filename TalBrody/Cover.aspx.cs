using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
			}

		    ChecktoHideDiv();
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