using TalBrody.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;

namespace TalBrody.DataLayer
{
	public class FollowerDal : BaseDal
	{

		public int Get_NmberOf_Followers_By_Project(int ProjectId)
		{			
			int Result = 0;
			try
			{
                using (var conn = PortalConection)
				{
					// TODO Fix SQL Injection
					var cmd = GetCommand("select count(*) from Followers where ProjectId = @ProjectId", conn);
					cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					cmd.CommandType = CommandType.Text;
					conn.Open();
					Result = int.Parse(cmd.ExecuteScalar().ToString());
					//	Result = int.Parse(myCommand.Parameters["@ProjectId"].ToString());

				}
			}
			catch (Exception)
			{
				throw;
			}
			return Result;
		}

        public List<Follower> Get_Follower_by_Project(int ProjectId)
        {
            List<Follower> PermissionList = new List<Follower>();

            using (var conn = PortalConection)
            {
                var cmd = GetCommand("SELECT [Id],[ProjectId],[UserId],[CreatedDate] FROM [Followers] where ProjectId = @ProjectId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PermissionList.Add(Populators.Populate_Follower(reader));
                }
            }
            return PermissionList;
        }
		
	}
}