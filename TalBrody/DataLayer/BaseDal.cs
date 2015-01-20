using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using log4net;

namespace fblogin.DataLayer
{
	public class BaseDal
	{
		public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public static dynamic GetPortalConnection()
		{
			string sqlType = ConfigurationManager.AppSettings["Sqlce"];
			string connectionString = ConfigurationManager.ConnectionStrings["OxifyConection"].ConnectionString;
			dynamic conn = null;
			if (sqlType == "True")
				conn = new SqlCeConnection(connectionString);
			else
				conn = new SqlConnection(connectionString);
			return conn;
		}


		public static dynamic GetCommand(string Command, dynamic conection)
		{
			string sqlType = ConfigurationManager.AppSettings["Sqlce"];
			dynamic Result = null;
			if (sqlType == "True")
				Result = new SqlCeCommand(Command, conection);
			else
				Result = new SqlCommand(Command, conection);

			return Result;
		}
	}
}