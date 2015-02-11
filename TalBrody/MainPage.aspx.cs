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
using TalBrody.Util;
using TalBrody.Common;

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

		[WebMethod(EnableSession = true)]
		public static int DoLOgIN(string id)
		{
			int result = 0;
			try
			{
				//TODO Ziv implemnet login
				/*
				Crypto crp = new Crypto();
				int UserId = int.Parse(crp.SignSymmetric(id));
				CommonFunction.AddUserToSession(UserId);
				*/
				result = 1;
			}
			catch (Exception ex)
			{
				
				throw ex;
			}
			return result;
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