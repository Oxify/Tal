using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{
	public class Perkses
	{
		public static List<Perks> GetAllPerksByProjectId(int ProjectId)
		{
			PerksDal dal = new PerksDal();
			List<Perks> PeksList = dal.GetAllPerksByProjectId(ProjectId);
			int Counter = 1;
			foreach (Perks item in PeksList)
			{
				item.CounterId = Counter;
				Counter++;
			}
			return PeksList;
		}
	}
}