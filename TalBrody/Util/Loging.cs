using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace TalBrody.Util
{	
	public class Loging
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static void InsertLog(string pageName,string Error)
		{
			string Err = "page name - " + pageName + " Error Date " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " Error-" + Error;
			log.Error(Err);
		}
	}
}