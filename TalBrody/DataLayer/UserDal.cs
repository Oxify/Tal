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
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
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

			int Result = 0;
			try
			{
				using (var conn = GetPortalConnection())
				{
                    // TODO Fix SQL Injection
					var cmd = GetCommand("select count(*) from Follwers where ProjectId = @ProjectId", conn);
					cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					cmd.CommandType = CommandType.Text;
					conn.Open();
					Result = int.Parse(cmd.ExecuteScalar().ToString());					
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
            using (var conn = GetPortalConnection())
            {
				var cmd = GetCommand("select Id, Email from Users where Email = @Email", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", email);
                
                conn.Open();
                var reader = cmd.ExecuteReader();
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

	    public void CreateUser(string email, string displayName)
	    {
	        using (var conn = GetPortalConnection())
	        {
				var cmd = GetCommand("insert into Users (Email, DisplayName) values (@Email, @DisplayName)", conn);
                cmd.CommandType = CommandType.Text;
	            cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@DisplayName", displayName);
                conn.Open();
	            var result = cmd.ExecuteNonQuery();
	            if (result != 1)
	            {
	                throw new Exception("Expected result 1, got " + result);
	            }
	        }
	    }
    }
}