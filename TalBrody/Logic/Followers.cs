using Oxify.DataLayer;
using Oxify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxify.Logic
{
	public class Followers
	{
		public static int Get_NmberOf_Follwers_By_Project(int ProjectId)
		{
			FollowerDal dal = new FollowerDal();
			return dal.Get_NmberOf_Follwers_By_Project(ProjectId);
		}
	}
}