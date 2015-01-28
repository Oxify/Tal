using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Entity
{
	public class OxifyParam
	{
		public int DbVersion { get; set; }
	}

    public class Param
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int? ValueInt { get; set; }

    }
}