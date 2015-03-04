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

        public static int Insert_Follwer(int ProjectId, int UserId,int RefUserId)
        {
            Follower foll = new Follower();
            foll.FollowerGuid = UUIDCreator.Create(8);
            foll.DateCreated = DateTime.Now;
            foll.ProjectId = ProjectId;
            foll.UserId = UserId;
            foll.ReferByUserId = RefUserId;
            return Insert_Follwer(foll);
        }

        public static void AddFollowerCount(string FollowerGuid)
        {
            FollowerDal dal = new FollowerDal();
            dal.AddFollowerCount(FollowerGuid);
        }

        public static Follower GET_Follower_BY_FollowerGuid(string FollowerGuid)
        {
            FollowerDal dal = new FollowerDal();
            return dal.GET_Follower_BY_FollowerGuid(FollowerGuid);
        }

        public static Follower GET_Follower_BY_UserId_and_project(int userId,int projectid)
        {
            FollowerDal dal = new FollowerDal();
            return dal.GET_Follower_BY_UserId_and_project(userId, projectid);
        }

	    public static string GetReferLink(int userId, int projectId)
	    {
            Follower fol = GET_Follower_BY_UserId_and_project(userId, projectId);
 
            string ShareUrl = string.Format("{0}?r={1}", IOC.GetInstance<UrlBuilder>().GetProjectUrl(), fol.FollowerGuid);
	        return ShareUrl;

	    }
	}
}