using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Entity
{
    public class Permission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int PermisstionId { get; set; }
    }
}