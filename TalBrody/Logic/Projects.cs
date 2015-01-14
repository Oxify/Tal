using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{
	public class Projects
	{
		public static Project GetProjectByProjectId(int ProjectId)
		{
			ProjectDal dal = new ProjectDal();
			return dal.GetProjectByProjectId(ProjectId);
		}

		public static List<Project> GetAllProject()
		{
			ProjectDal dal = new ProjectDal();
			return dal.GetAllProject();
		}
	}
}