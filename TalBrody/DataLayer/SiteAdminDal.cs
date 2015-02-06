using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
    public class SiteAdminDal : BaseDal
    {
        public int InsertSiteAdmin(SiteAdmin sadmin)
        {
            int SiteAdminId = 0;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("insert into SiteAdmin (UserId) values (@UserId) 	" +
                                     "SELECT Id FROM SiteAdmin WHERE Id = @@IDENTITY;", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserId", sadmin.UserId);
                //cmd.Parameters.Add("@SiteAdminId", SqlDbType.Int).Direction = ParameterDirection.Output;
                conn.Open();
                SiteAdminId = (int)cmd.ExecuteScalar();
               
            }
            return SiteAdminId;
        }

        public SiteAdmin GetSiteAdminByUserId(int UserId)
        {
            SiteAdmin sadmin = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select [Id], [UserId]" +
                                     " from SiteAdmin where UserId = @UserId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserId", UserId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sadmin = Populators.Populate_SiteAdmin(reader);
                }
                return sadmin;
            }

        }
    }
}