using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Entity
{
    public class ProjectEntity
	{
		public string DisplayName { get; set; }
		public string ShortName { get; set; }
		public string Description { get; set; }
		public int id { get; set; }
		public string LinkUrl { get; set; }
		public string MovieUrl { get; set; }
	}
}