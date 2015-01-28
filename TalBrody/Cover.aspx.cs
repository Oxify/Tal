﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
		}

		private void InitParam()
		{
			LblTitle.Style.Add("font-size", "30px");
		}
	}
}