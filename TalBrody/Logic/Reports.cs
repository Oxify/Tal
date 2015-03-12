using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{
    public class Reports
    {
        public static List<Report_Join> Get_Report_Join(DateTime From,DateTime To,int ProjectId)
        {
            ReportDal dal = new ReportDal();
            return dal.GET_Follower_BY_UserId_and_project(From, To, ProjectId);
        }
    }
}