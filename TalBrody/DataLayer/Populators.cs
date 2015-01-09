using fblogin.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fblogin.DataLayer
{
	public class Populators
	{
		

		internal static Follower Populate_Follower(SqlDataReader dr)
		{
			Follower Consept = new Follower();
			Consept.ContactEmail = dr.GetValue<string>("ContactEmail");
			Consept.DateCreated = dr.GetValue<DateTime>("DateCreated");
			Consept.ConseptId = dr.GetValue<int>("ConseptId");
			Consept.count = dr.GetValue<int>("count");
			Consept.ContactId = dr.GetValue<int>("ContactId");
			return Consept;
		}
	}
}