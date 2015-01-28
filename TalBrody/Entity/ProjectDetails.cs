using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Entity
{
	public class ProjectDetails
	{
		public int Id { get; set; }
		public int ProjectId { get; set; }
		public int FieldId { get; set; }
		public int LangId { get; set; }
		public string Text { get; set; }
		public int FontSize { get; set; }

	}
}