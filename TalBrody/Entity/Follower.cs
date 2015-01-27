using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fblogin.Entity
{
	public class Follower
	{
		public int ContactId { get; set; }
		public string ContactEmail { get; set; }
		public DateTime DateCreated { get; set; }
		public int ConseptId { get; set; }
		public int count { get; set; }
	}
}