using TalBrody.DataLayer;
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
	public class BdHandlingDal : BaseDal
	{
		public void ExcuteDbCommand(string ExcuteCommand)
		{
			try
			{
                var myConnection = PortalConection;
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
				Log.Error("GetAllProject Threw: " + ex.ToString());
				throw;
			}
		}
	}
}