using fblogin.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fblogin.Logic
{
	public class Users
	{
		public static int Get_NmberOf_Follwers_By_Project(int ProjectId)
		{
			UserDal dal = new UserDal();
			return dal.Get_NmberOf_Follwers_By_Project(ProjectId);
		}
	}
}