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
        public static ProjectEntity GetProjectByProjectId(int ProjectId)
        {
            ProjectDal dal = new ProjectDal();
            return dal.GetProjectByProjectId(ProjectId);
        }

        public static List<ProjectEntity> GetAllProject()
        {
            ProjectDal dal = new ProjectDal();
            List<ProjectEntity> proloist = dal.GetAllProject();
            int Counter = 1;
            foreach (ProjectEntity item in proloist)
            {
                item.ProjectCount = Counter;
                Counter++;
            }
            return proloist;
        }
    }
}