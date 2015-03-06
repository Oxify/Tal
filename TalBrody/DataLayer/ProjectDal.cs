using TalBrody.DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
	public class ProjectDal : BaseDal
	{
        public ProjectEntity GetProjectByProjectId(int ProjectId)
		{
            ProjectEntity Pro = null;
			try
			{
                var myConnection = PortalConection;
				using (myConnection)
				{
					var myCommand = GetCommand("SELECT id, DisplayName, ShortName, Description, LinkUrl, MovieUrl FROM Projects where id = @ProjectId" , myConnection);
					
					myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;
					//SqlCeDataReader drs = null;
					//var dr = drs;
					myConnection.Open();

					var dr = myCommand.ExecuteReader();
					while (dr.Read())
					{
						Pro = Populators.Populate_Project(dr);
					}
					myConnection.Close();
					dr.Close();
					//	Result = int.Parse(myCommand.Parameters["@ProjectId"].ToString());
				}

			}
			catch (Exception ex)
			{
				Log.Error("GetProjectByProjectId Threw: " + ex.ToString());
				throw;
			}
			return Pro;
		}

        public List<ProjectEntity> GetAllProject()
		{
            List<ProjectEntity> ProList = new List<ProjectEntity>();
			try
			{
                var myConnection = PortalConection;
				using (myConnection)
				{
					var myCommand = GetCommand("SELECT id, DisplayName, ShortName, Description, LinkUrl, MovieUrl FROM Projects ", myConnection);
					//myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;					
					myConnection.Open();
					var dr = myCommand.ExecuteReader();
					while (dr.Read())
					{
						ProList.Add(Populators.Populate_Project(dr));
					}
					myConnection.Close();
					dr.Close();
					//	Result = int.Parse(myCommand.Parameters["@ProjectId"].ToString());
				}

			}
			catch (Exception ex)
			{
				Log.Error("GetAllProject Threw: " + ex.ToString());
				throw;
			}
			return ProList;
		}
	}
}