using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.Util
{
    public class UserSession
    {
        public int UserId { get; set; }
        public DateTime StartSession { get; set; }
        public List<Permission> PermissionList { get; set; }
    }
}