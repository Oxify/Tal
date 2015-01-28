using TalBrody.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TalBrody
{
	public partial class MainPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			InitParamk();
		}

		private void InitParamk()
		{

		}

		protected void TextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		[WebMethod(EnableSession = true)]
		public static string GetAutoConsept(string Consept)
		{
			

			return "";
		}		

		protected void BtnConseptIn_Click(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		protected void BtnEmailEnter_Click(object sender, EventArgs e)
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