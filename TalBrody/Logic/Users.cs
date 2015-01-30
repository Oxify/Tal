using TalBrody.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.Logic
{
	public class Users
	{
		public static User FindUserByEmail(string email)
		{
			UserDal dal = new UserDal();
			return dal.FindUserByEmail(email);
		}
	}
}