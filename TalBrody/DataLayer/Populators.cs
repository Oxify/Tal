using System;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
	public class Populators
	{
		
		internal static Follower Populate_Follower(SqlDataReader dr)
		{
			Follower Consept = new Follower();
			Consept.ContactEmail = dr.GetValue<string>("ContactEmail");
			Consept.DateCreated = dr.GetValue<DateTime>("DateCreated");
			Consept.ConseptId = dr.GetValue<int>("ConseptId");
			Consept.count = dr.GetValue<int>("count");
			Consept.ContactId = dr.GetValue<int>("ContactId");
			return Consept;
		}

		internal static Follower Populate_Follower(SqlCeDataReader dr)
		{
			Follower Consept = new Follower();
			Consept.ContactEmail = dr.GetValue<string>("ContactEmail");
			Consept.DateCreated = dr.GetValue<DateTime>("DateCreated");
			Consept.ConseptId = dr.GetValue<int>("ConseptId");
			Consept.count = dr.GetValue<int>("count");
			Consept.ContactId = dr.GetValue<int>("ContactId");
			return Consept;
		}

		internal static Perks Populate_Perks(SqlCeDataReader dr)
		{
			Perks Perks = new Perks();
			Perks.Cost = dr.GetValue<int>("Cost");
			Perks.Description = dr.GetValue<string>("Description");
			Perks.PerkId = dr.GetValue<int>("PerkId");
			Perks.ProjectId = dr.GetValue<int>("ProjectId");
			Perks.ShowOrder = dr.GetValue<int>("ShowOrder");
			Perks.Title = dr.GetValue<string>("Title");
			return Perks;
		}

		internal static Perks Populate_Perks(SqlDataReader dr)
		{
			Perks Perks = new Perks();
			Perks.Cost = dr.GetValue<int>("Cost");
			Perks.Description = dr.GetValue<string>("Description");
			Perks.PerkId = dr.GetValue<int>("PerkId");
			Perks.ProjectId = dr.GetValue<int>("ProjectId");
			Perks.ShowOrder = dr.GetValue<int>("ShowOrder");
			Perks.Title = dr.GetValue<string>("Title");
			return Perks;
		}

		internal static Project Populate_Project(SqlCeDataReader dr)
		{
			Project Project = new Project();
			Project.Description = dr.GetValue<string>("Description");
			Project.DisplayName = dr.GetValue<string>("DisplayName");
			Project.id = dr.GetValue<int>("id");
			Project.LinkUrl = dr.GetValue<string>("LinkUrl");
			Project.MovieUrl = dr.GetValue<string>("MovieUrl");
			Project.ShortName = dr.GetValue<string>("ShortName");
			return Project;
		}

		internal static Project Populate_Project(SqlDataReader dr)
		{
			Project Project = new Project();
			Project.Description = dr.GetValue<string>("Description");
			Project.DisplayName = dr.GetValue<string>("DisplayName");
			Project.id = dr.GetValue<int>("id");
			Project.LinkUrl = dr.GetValue<string>("LinkUrl");
			Project.MovieUrl = dr.GetValue<string>("MovieUrl");
			Project.ShortName = dr.GetValue<string>("ShortName");
			return Project;
		}

	    internal static Param Populate_Params(SqlDataReader dr)
	    {
            Param param = new Param();
	        param.Name = dr.GetValue<string>("Name");
	        param.Value = dr.GetValue<string>("Value");
	        param.ValueInt = dr.GetInt32(dr.GetOrdinal("ValueInt"));
	        
            return param;
	    }
        internal static Param Populate_Params(SqlCeDataReader dr)
        {
            Param param = new Param();
            param.Name = dr.GetValue<string>("Name");
            param.Value = dr.GetValue<string>("Value");
            param.ValueInt = dr.GetInt32(dr.GetOrdinal("ValueInt"));

            return param;
        }

	}
}