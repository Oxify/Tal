using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TalBrody
{
    public partial class EditProject : System.Web.UI.Page
    {
        public int ProjectId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitParam();
            }
        }

        private void InitParam()
        {
            ProjectId = int.Parse(Request["ProjectId"]);
        }

        private void PopulateFollwers()
        {


        }
    }
}