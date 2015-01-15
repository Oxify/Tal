﻿using System.Configuration;
using fblogin.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;
using log4net;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
	public class PerksDal: BaseDal
	{
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public List<Perks> GetAllPerksByProjectId(int ProjectId)
		{
			List<Perks> Result = new List<Perks>();
			try
			{
				using (SqlCeConnection myConnection = GetPortalConnection())
				{
					SqlCeCommand myCommand = new SqlCeCommand("select Cost,Description,PerkId,ProjectId,ShowOrder,Title from Perks where ProjectId = " + ProjectId + "order by ShowOrder", myConnection);
					//myCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = ProjectId;
					myCommand.CommandType = CommandType.Text;
					SqlCeDataReader dr =null;
					myConnection.Open();					
					
					dr = myCommand.ExecuteReader();
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
                log.Error("GetAllPerksByProjectId Threw: " + ex.ToString());

				throw ex;
			}
			return Result;
		}
	}
}