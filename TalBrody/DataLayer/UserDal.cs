using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using fblogin.Entity;
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
				using (var myConnection = GetPortalConnection())
				{
                    // TODO Fix SQL Injection
					var myCommand = new SqlCeCommand("select count(*) from Follwers where ProjectId = " + ProjectId, myConnection);
					//myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;
					myConnection.Open();
					Result = int.Parse(myCommand.ExecuteScalar().ToString());					
				//	Result = int.Parse(myCommand.Parameters["@ProjectId"].ToString());

				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Result;
		}

	    public User FindUserByEmail(string email)
	    {
            using (var myConnection = GetPortalConnection())
            {
                // TODO Fix SQL Injection
//                var myCommand = new SqlCeCommand("select Id, Email from Users where Email = " + email, myConnection);
                var myCommand = new SqlCeCommand("select Id, Email from Users where Email = @Email", myConnection);
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;

                myCommand.CommandType = CommandType.Text;

                myConnection.Open();
                var reader = myCommand.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }

                var user = new User
                {
                    Id = (int) reader[0], 
                    Email = (string) reader[1]
                };
                return user;
            }
	    }
	}
}