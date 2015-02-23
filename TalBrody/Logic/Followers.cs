using TalBrody.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Util;

namespace TalBrody.Logic
{
	public class Followers
	{
		public static int Get_NumberOf_Followers_By_Project(int ProjectId)
		{
			FollowerDal dal = new FollowerDal();
			return dal.Get_NmberOf_Followers_By_Project(ProjectId);
		}

        public static List<Follower> Get_Follower_by_Project(int ProjectId)
        {
            FollowerDal dal = new FollowerDal();
            return dal.Get_Follower_by_Project(ProjectId);
        }

        public static int Insert_Follwer(Follower foll)
        {
            FollowerDal dal =  new FollowerDal();
            return dal.Insert_Follwer(foll);
        }

        public static int Insert_Follwer(int ProjectId, int UserId)
        {
            Follower foll = new Follower();
            foll.FollowerGuid = UUIDCreator.Create(8);
            foll.DateCreated = DateTime.Now;
            foll.ProjectId = ProjectId;
            foll.UserId = UserId;
            return Insert_Follwer(foll);
        }

        public static void AddFollowerCount(string FollowerGuid)
        {
            FollowerDal dal = new FollowerDal();

        }
	}
}