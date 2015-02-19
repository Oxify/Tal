using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
    public class PermissionDal : BaseDal
    {
        public List<Permission> GetAllPermissionByUserId(int UserId)
        {
            List<Permission> PermissionList = new List<Permission>();
            
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select Id, UserId, ProjectId, PermisstionName" +
                                     " from Permissions where UserId = @UserId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserId", UserId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PermissionList.Add(Populators.Populate_permission(reader));
                }
            }
            return PermissionList;
        }

        public void InsertPermission(Permission per)
        {
            try
            {
                using (var myConnection = PortalConection)
                {
                    var myCommand = GetCommand("INSERT INTO [Permissions]([UserId],[ProjectId],[PermisstionId])"+
                        " VALUES(@UserId,@ProjectId ,@PermisstionId);", myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = per.UserId;
                    myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = per.ProjectId;
                    myCommand.Parameters.Add("@PermisstionId", SqlDbType.Int).Value = per.PermisstionId;                   

                    myConnection.Open();
                    var result = myCommand.ExecuteNonQuery();
                    if (result != 1)
                    {
                        throw new Exception("Expected result 1, got " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("InsertParam Threw: " + ex);
                throw;
            }
        }

        public void RemovePermission(int Id)
        {
            try
            {
                using (var myConnection = PortalConection)
                {
                    var myCommand = GetCommand("delete from [Permissions] where Id = @Id);", myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                   
                    myConnection.Open();
                    var result = myCommand.ExecuteNonQuery();
                    if (result != 1)
                    {
                        throw new Exception("Expected result 1, got " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("InsertParam Threw: " + ex);
                throw;
            }
        }
    }
}