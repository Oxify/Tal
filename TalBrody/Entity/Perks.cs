using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Entity
{
	public class Perks
	{
		public int PerkId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Cost { get; set; }
		public int ShowOrder { get; set; }
		public int ProjectId { get; set; }
	}
}