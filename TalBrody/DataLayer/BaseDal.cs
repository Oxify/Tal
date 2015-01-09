using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlServerCe;

namespace fblogin.DataLayer
{
	public class BaseDal
	{
		public static SqlCeConnection GetPortalConnection()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["OxifyConection"].ConnectionString;
			SqlCeConnection conn = new SqlCeConnection(connectionString);
			return conn;
		}
	}
}