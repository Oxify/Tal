using fblogin.DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
	public class ProjectDal : BaseDal
	{
		public Project GetProjectByProjectId(int ProjectId)
		{
			Project Pro = null;
			try
			{
				using (SqlCeConnection myConnection = GetPortalConnection())
				{
					SqlCeCommand myCommand = new SqlCeCommand("SELECT id, DisplayName, ShortName, Description, LinkUrl, MovieUrl FROM Projects where id = " + ProjectId, myConnection);
					//myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;
					SqlCeDataReader dr = null;
					myConnection.Open();

					dr = myCommand.ExecuteReader();
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

				throw ex;
			}
			return Pro;
		}

		public List<Project> GetAllProject()
		{
			List<Project> ProList = new List<Project>();
			try
			{
				using (SqlCeConnection myConnection = GetPortalConnection())
				{
					SqlCeCommand myCommand = new SqlCeCommand("SELECT id, DisplayName, ShortName, Description, LinkUrl, MovieUrl FROM Projects ", myConnection);
					//myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;
					SqlCeDataReader dr = null;
					myConnection.Open();

					dr = myCommand.ExecuteReader();
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

				throw ex;
			}
			return ProList;
		}
	}
}