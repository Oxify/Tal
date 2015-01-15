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
		public  static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public static SqlCeConnection GetPortalConnection()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["OxifyConection"].ConnectionString;
			SqlCeConnection conn = new SqlCeConnection(connectionString);
			return conn;
		}
	}
}