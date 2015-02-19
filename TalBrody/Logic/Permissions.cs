using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.Common.Enums;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{
    public class Permissions
    {
        public static List<Permission> Get_All_Permission_By_UserId(int UserId)
        {
            var permissionList = new List<Permission>();
            SiteAdmin sadmin = SiteAdmins.GetSiteAdminByUserId(UserId);
            if (sadmin != null)
            {
                var p = new Permission
                {
                    Id = -99,
                    PermisstionId = (int)PermisstionEnum.Admin,
                    ProjectId = -99,
                    UserId = UserId
                };
                permissionList.Add(p);
            }
            else
            {
                PermissionDal dal = new PermissionDal();
                permissionList = dal.GetAllPermissionByUserId(UserId);
            }
            return permissionList;
        }

        public static void InsertPermission(Permission per)
        {
            PermissionDal dal = new PermissionDal();
            dal.InsertPermission(per);
        }

        public static void RemovePermission(int Id)
        {
            PermissionDal dal = new PermissionDal();
            dal.RemovePermission(Id);
        }
    }
}