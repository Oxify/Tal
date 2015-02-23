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

        public void AddFollowerCount(string FollowerGuid)
        {           
            try
            {
                using (var conn = PortalConection)
                {
                    // TODO Fix SQL Injection
                    var cmd = GetCommand("update Followers set FollowerCount = FollowerCount + 1 where FollowerGuid = @FollowerGuid ", conn);
                    cmd.Parameters.AddWithValue("@FollowerGuid", FollowerGuid);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public int Insert_Follwer(Follower Foll)
        {
            int FollowerID = 0;
            using (var conn = PortalConection)
            {
                conn.Open();
                var cmd = GetCommand("INSERT INTO [Followers]([ProjectId],[UserId],[CreatedDate],[FollowerGuid])" +
                                    "VALUES (@ProjectId,@UserId,@CreatedDate,@FollowerGuid);", conn);
                var tr = conn.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProjectId", Foll.ProjectId);
                cmd.Parameters.AddWithValue("@UserId", Foll.UserId);
                cmd.Parameters.AddWithValue("@CreatedDate", Foll.DateCreated);
                cmd.Parameters.AddWithValue("@FollowerGuid", Foll.FollowerGuid);               

                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();

                cmd = GetCommand("SELECT @@IDENTITY AS ID", conn);
                cmd.Transaction = tr;
                object o = cmd.ExecuteScalar();
                FollowerID = Convert.ToInt32(o);

                tr.Commit();
            }
            return FollowerID;
        }

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
                var cmd = GetCommand("SELECT [Id],[ProjectId],[UserId],[CreatedDate],FollowerGuid,FollowerCount FROM [Followers] where ProjectId = @ProjectId", conn);
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