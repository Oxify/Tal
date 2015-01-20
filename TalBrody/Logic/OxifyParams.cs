using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{
	public class OxifyParams
	{
		public static OxifyParam GetOxifyParam()
		{
			OxifyParamDal dal = new OxifyParamDal();
			return dal.GetOxifyParam();
		}

		public static void UpdateOxifyParam(OxifyParam Param)
		{
			OxifyParamDal dal = new OxifyParamDal();
			dal.UpdateOxifyParam(Param);
		}
	}
}