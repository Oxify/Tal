using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
	public class ProjectDetailsDal : BaseDal
	{
		public List<ProjectDetails> GetProjectDetails(int ProjectId,int LangId)
		{
			List<ProjectDetails> Result = new List<ProjectDetails>();
			try
			{
                using (var myConnection = PortalConection())
				{
					var myCommand = GetCommand("SELECT Id ,ProjectId,FieldId ,LangId ,Text  ,FontSize FROM dbo.ProjectDetails where ProjectId = @ProjectId and LangId = @LangId", myConnection);
					myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.Parameters.Add("@LangId", SqlDbType.Int).Value = LangId;
					myCommand.CommandType = CommandType.Text;
					myConnection.Open();
					var dr = myCommand.ExecuteReader();
					while (dr.Read())
					{
						Result.Add(Populators.Populate_projectDetails(dr));
					}
					myConnection.Close();
					dr.Close();
				}
			}
			catch (Exception ex)
			{
				Log.Error("GetProjectDetails Threw: " + ex.ToString());
				throw;
			}
			return Result;
		}
	}
}