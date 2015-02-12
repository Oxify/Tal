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
                    PermissionList.Add(Populators.Populate_SiteAdmin(reader));
                }
            }
            return PermissionList;
        }
    }
}