using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Entity
{
	public class Follower
	{
		public int Id { get; set; }
        public int ProjectId { get; set; }
		public DateTime DateCreated { get; set; }
        public int UserId { get; set; }

        public string FollowerGuid { get; set; }

        public int FollowerCount { get; set; }
		
	}
}