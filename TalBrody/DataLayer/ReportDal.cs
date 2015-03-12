using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
    public class ReportDal : BaseDal
    {
        public List<Report_Join> GET_Follower_BY_UserId_and_project(DateTime From, DateTime To, int ProjectId)
        {
            List<Report_Join> repo = new List<Report_Join>();

            using (var conn = PortalConection)
            {
                var cmd = GetCommand("SELECT count( [Id]) as Count,cast(floor(cast(CreatedDate as float)) as datetime) as Date" +
                    " FROM [Followers] where ProjectId = @ProjectId and CreatedDate >= @From" +
                    " and CreatedDate <= @To group by cast(floor(cast(CreatedDate as float)) as datetime)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@From", From);
                cmd.Parameters.AddWithValue("@To", To);
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    repo.Add(Populators.Populate_Report_Join(reader));
                }
            }
            return repo;
        }
    }
}