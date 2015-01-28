using TalBrody.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalBrody.Entity;
using log4net;

namespace TalBrody.DataLayer
{
	public class OxifyParamDal : BaseDal
	{
		public OxifyParam GetOxifyParam()
		{
			OxifyParam Result = null;
			try
			{
				using (var myConnection = GetPortalConnection())
				{
					var myCommand = GetCommand("select Id,DbVersion from OxifyParam", myConnection);
					//myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;					
					myConnection.Open();
					var dr = myCommand.ExecuteReader();
					while (dr.Read())
					{
						Result = Populators.Populate_OxifyParam(dr);
					}
					myConnection.Close();
					dr.Close();					
				}
			}
			catch (Exception ex)
			{
                log.Error("GetOxifyParam Threw: " + ex.ToString());

				Result = new OxifyParam();
                Result.DbVersion = 0;
			}
			return Result;
		}

		public void UpdateOxifyParam(OxifyParam Param)
		{			
			try
			{
				using (var myConnection = GetPortalConnection())
				{
					var myCommand = GetCommand("update [OxifyParam] set [DbVersion] = @Dbversion", myConnection);
					myCommand.Parameters.Add("@Dbversion", SqlDbType.Int).Value = Param.DbVersion;
					myCommand.CommandType = CommandType.Text;
					myConnection.Open();
					myCommand.ExecuteNonQuery();
					myConnection.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error("GetAllPerksByProjectId Threw: " + ex.ToString());
				throw ex;
			}			
		}
	}
}