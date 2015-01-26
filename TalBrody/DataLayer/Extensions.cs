using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;

namespace Oxify.DataLayer
{
	public static class Extensions
	{
		public static T GetValue<T>(this SqlDataReader reader, string name)
		{
			object obj = reader.GetValue(reader.GetOrdinal(name));
			if (obj != null && reader.GetValue(reader.GetOrdinal(name)) != DBNull.Value)
				return (T)Convert.ChangeType(obj, typeof(T));
			return default(T);
		}

		public static T GetValue<T>(this SqlCeDataReader reader, string name)
		{
			object obj = reader.GetValue(reader.GetOrdinal(name));
			if (obj != null && reader.GetValue(reader.GetOrdinal(name)) != DBNull.Value)
				return (T)Convert.ChangeType(obj, typeof(T));
			return default(T);
		}
	}
}