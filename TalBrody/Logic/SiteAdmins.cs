using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{
    public class SiteAdmins
    {
        public static int InsertSiteAdmin(SiteAdmin sadmin)
        {
            SiteAdminDal dal = new SiteAdminDal();
            return dal.InsertSiteAdmin(sadmin);
        }

        public static SiteAdmin GetSiteAdminByUserId(int UserId)
        {
            SiteAdminDal dal = new SiteAdminDal();
            return dal.GetSiteAdminByUserId(UserId);
        }
    }
}