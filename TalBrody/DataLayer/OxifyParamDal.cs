﻿using fblogin.DataLayer;
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
				log.Error("GetAllPerksByProjectId Threw: " + ex.ToString());
				throw ex;
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

		public bool CheckOxifyParamExists()
		{
			bool exists = false;
			try
			{
				using (var myConnection = GetPortalConnection())
				{
					var myCommand = GetCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE  TABLE_NAME = 'OxifyParam'and TABLE_SCHEMA = 'dbo'", myConnection);					
					myCommand.CommandType = CommandType.Text;
					myConnection.Open();
					var dr = myCommand.ExecuteReader();
					while (dr.Read())
					{
						exists = true;
					}
					myConnection.Close();
					dr.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error("CheckOxifyParamExists Threw: " + ex.ToString());
				throw ex;
			}
			return exists;
		}	
	}
}