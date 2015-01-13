using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;

namespace fblogin.DataLayer
{
	public class UserDal : BaseDal
	{
		public int Get_NmberOf_Follwers_By_Project(int ProjectId)
		{
            Console.WriteLine("Number of followers, OnAppHarbor = " + ConfigurationManager.AppSettings["OnAppHarbor"]);
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