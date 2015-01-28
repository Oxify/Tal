using TalBrody.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;

namespace TalBrody.Logic
{
	public class Followers
	{
		public static int Get_NmberOf_Followers_By_Project(int ProjectId)
		{
			FollowerDal dal = new FollowerDal();
			return dal.Get_NmberOf_Followers_By_Project(ProjectId);
		}
	}
}