using fblogin.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
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
				using (SqlCeConnection myConnection = GetPortalConnection())
				{
					SqlCeCommand myCommand = new SqlCeCommand("select Id,DBVersion from OxifyParam", myConnection);
					//myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;
					SqlCeDataReader dr = null;
					myConnection.Open();

					dr = myCommand.ExecuteReader();
					while (dr.Read())
					{
						Result = Populators.Populate_OxifyParam(dr);
					}
					myConnection.Close();
					dr.Close();
					//	Result = int.Parse(myCommand.Parameters["@ProjectId"].ToString());
				}

			}
			catch (Exception ex)
			{
				log.Error("GetAllPerksByProjectId Threw: " + ex.ToString());

				throw ex;
			}
			return Result;
		}
	}
}