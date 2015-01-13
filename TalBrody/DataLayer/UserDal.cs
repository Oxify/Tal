using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using log4net;

namespace fblogin.DataLayer
{
	public class UserDal : BaseDal
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public int Get_NmberOf_Follwers_By_Project(int ProjectId)
		{
		    string OnAppHarbor = ConfigurationManager.AppSettings["OnAppHarbor"];
            log.Info("Log4Net: Number of followers, OnAppHarbor = "+  OnAppHarbor);
            Trace.TraceError("TraceError: Number of followers, OnAppHarbor = "+  OnAppHarbor);
            if (ConfigurationManager.AppSettings["OnAppHarbor"].ToLower() == "true")
            {
                return 100;
            }

			int Result = 0;
			try
			{
				using (SqlCeConnection myConnection = GetPortalConnection())
				{
					SqlCeCommand myCommand = new SqlCeCommand("select count(*) from Follwers where ProjectId = " + ProjectId, myConnection);
					//myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;
					myConnection.Open();
					Result = int.Parse(myCommand.ExecuteScalar().ToString());					
					myConnection.Close();
				//	Result = int.Parse(myCommand.Parameters["@ProjectId"].ToString());

				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Result;
		}
	}
}