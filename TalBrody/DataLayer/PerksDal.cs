using System.Configuration;
using TalBrody.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using log4net;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
	public class PerksDal: BaseDal
	{
       

		public List<Perks> GetAllPerksByProjectId(int ProjectId)
		{
			List<Perks> Result = new List<Perks>();
			try
			{
                var myConnection = PortalConection;
				using (myConnection)
				{
					var myCommand = GetCommand("select Cost,Description,PerkId,ProjectId,ShowOrder,Title from Perks where ProjectId = @ProjectId order by ShowOrder", myConnection);
					myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;
					
					myConnection.Open();					
					
					var dr = myCommand.ExecuteReader();
					while (dr.Read())
					{
						Result.Add(Populators.Populate_Perks(dr));
					}		
					myConnection.Close();
					dr.Close();
				//	Result = int.Parse(myCommand.Parameters["@ProjectId"].ToString());
				}

			}
			catch (Exception ex)
			{
                Log.Error("GetAllPerksByProjectId Threw: " + ex.ToString());

				throw ex;
			}
			return Result;
		}
	}
}