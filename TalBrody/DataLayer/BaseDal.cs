using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using log4net;
using TalBrody;

namespace Oxify.DataLayer
{
	public class BaseDal
	{
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string GetAppHarborConnectionString()
        {
            var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];
            var uri = new Uri(uriString);
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = uri.Host,
                InitialCatalog = uri.AbsolutePath.Trim('/'),
                UserID = uri.UserInfo.Split(':').First(),
                Password = uri.UserInfo.Split(':').Last(),
            }.ConnectionString;

            return connectionString;
        }

		public static dynamic GetPortalConnection()
		{
            dynamic conn = null;
            if (Global.OnAppHarbor)
            {
                string connectionString = GetAppHarborConnectionString();
                log.Info("GetPortalConnection: OnAppHarbor, connection string: " + connectionString);
                conn = new SqlConnection(connectionString);
            }
            else
            {
    			string connectionString = ConfigurationManager.ConnectionStrings["OxifyConection"].ConnectionString;
                log.Info("GetPortalConnection: Not OnAppHarbor, connection string: " + connectionString);
                conn = new SqlCeConnection(connectionString);
            }
			return conn;
		}


		public static dynamic GetCommand(string Command, dynamic conection)
		{
			dynamic Result = null;
			if (Global.OnAppHarbor)
            {
				Result = new SqlCommand(Command, conection);
            }
            else
            {
				Result = new SqlCeCommand(Command, conection);
            }

			return Result;
		}
	}
}