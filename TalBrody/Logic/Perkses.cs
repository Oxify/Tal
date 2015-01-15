using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{
	public class Perkses
	{
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static List<Perks> GetAllPerksByProjectId(int ProjectId)
		{
			PerksDal dal = new PerksDal();
			List<Perks> PeksList = dal.GetAllPerksByProjectId(ProjectId);
			int Counter = 1;
		    if (PeksList.Count == 0)
		    {
                log.Info("No perks for project #" + ProjectId);

		        return PeksList;
		    }
			foreach (Perks item in PeksList)
			{
				item.CounterId = Counter;
				Counter++;
			}
			return PeksList;
		}
	}
}