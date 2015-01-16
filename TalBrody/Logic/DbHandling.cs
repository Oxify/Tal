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
			int CurrentStatus = CurrentDbVersion;

			try
			{
				while (CurrentStatus <= DestanationDbVersion)
				{
					switch (CurrentStatus)
					{
						case 0:
							DBHandling0();
							break;
						case 1:
							DBHandling1();
							break;
						case 2:
							DBHandling2();
							break;
						default:
							break;
					}
				}
			}
			catch (Exception ex)
			{
				Loging.InsertLog("DbHandling", "UpgradeDbVerstion Threw: " + ex.ToString());
				throw ex;
			}
			return Result;
		}

		private void DBHandling2()
		{
			throw new NotImplementedException();
		}

		private void DBHandling1()
		{
			throw new NotImplementedException();
		}

		private void DBHandling0()
		{
			
		}
	}
}