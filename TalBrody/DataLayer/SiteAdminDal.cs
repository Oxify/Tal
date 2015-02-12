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
                conn.Open();
                var cmd = GetCommand("insert into SiteAdmin (UserId) values (@UserId); ",conn);
               
                var tr = conn.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserId", sadmin.UserId);

                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();

                cmd = GetCommand("SELECT @@IDENTITY AS ID", conn);
                cmd.Transaction = tr;
                object o = cmd.ExecuteScalar();
                SiteAdminId = Convert.ToInt32(o);

                tr.Commit();
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