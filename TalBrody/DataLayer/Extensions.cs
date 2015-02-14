using System;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace TalBrody.DataLayer
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
        public static SqlParameter AddWithNullableValue(this SqlParameterCollection collection, string parameterName, object value)
        {
            return collection.AddWithValue(parameterName, value ?? DBNull.Value);
        }

	    public static SqlCeParameter AddWithNullableValue(this SqlCeParameterCollection collection, string parameterName, object value)
	    {
	        return collection.AddWithValue(parameterName, value ?? DBNull.Value);
	    }
	}
}