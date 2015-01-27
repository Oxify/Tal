using fblogin.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalBrody.Entity;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace TalBrody.DataLayer
{
	public class BdHandlinkDal : BaseDal
	{
		public void ExcuteDbCommand(string ExcuteCommand)
		{
			try
			{
				var myConnection = GetPortalConnection();
				using (myConnection)
				{
					var myCommand = GetCommand(ExcuteCommand, myConnection);
					myCommand.CommandType = CommandType.Text;
					myConnection.Open();
					myCommand.ExecuteNonQuery();
					myConnection.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error("GetAllProject Threw: " + ex.ToString());
				throw ex;
			}
		}
	}
}