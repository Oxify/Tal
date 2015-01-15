using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.Util;


namespace TalBrody.Logic
{
	public class DbHandling
	{
		public bool UpgradeDbVerstion(int CurrentDbVersion, int DestanationDbVersion)
		{
			bool Result = false;
			try
			{

			}
			catch (Exception ex)
			{
				Loging.InsertLog("DbHandling", "UpgradeDbVerstion Threw: " + ex.ToString());
				throw ex;
			}
			return Result;
		}
	}
}