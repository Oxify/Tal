using System;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
	public class Populators : BaseDal
	{
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

		internal static ProjectDetails Populate_projectDetails(SqlDataReader dr)
		{
			ProjectDetails ProjectDetails = new ProjectDetails();
			ProjectDetails.FieldId = dr.GetValue<int>("FieldId");
			ProjectDetails.FontSize = dr.GetValue<int>("FontSize");
			ProjectDetails.Id = dr.GetValue<int>("Id");
			ProjectDetails.LangId = dr.GetValue<int>("LangId");
			ProjectDetails.ProjectId = dr.GetValue<int>("ProjectId");
			ProjectDetails.Text = dr.GetValue<string>("Text");
			return ProjectDetails;
		}

		internal static ProjectDetails Populate_projectDetails(SqlCeDataReader dr)
		{
			ProjectDetails ProjectDetails = new ProjectDetails();
			ProjectDetails.FieldId = dr.GetValue<int>("FieldId");
			ProjectDetails.FontSize = dr.GetValue<int>("FontSize");
			ProjectDetails.Id = dr.GetValue<int>("Id");
			ProjectDetails.LangId = dr.GetValue<int>("LangId");
			ProjectDetails.ProjectId = dr.GetValue<int>("ProjectId");
			ProjectDetails.Text = dr.GetValue<string>("Text");
			return ProjectDetails;
		}

		internal static User Populate_User(SqlDataReader dr)
		{
			User User = new User();
			User.DisplayName = dr.GetValue<string>("DisplayName");
			User.Email = dr.GetValue<string>("Email");
			User.FaceBookId = dr.GetValue<long>("FaceBookId");
			User.Id = dr.GetValue<int>("Id");
		    User.EmailConfirmed = dr.GetValue<bool>("EmailConfirmed");
			User.PasswordHash = dr.GetValue<byte[]>("PasswordHash");
			User.PasswordSalt = dr.GetValue<byte[]>("PasswordSalt");
            User.ReferancedBy = dr.GetValue<string>("ReferencedBy");
            User.TwitterId = dr.GetValue<string>("TwitterId");
			return User;
		}

        internal static User Populate_User(SqlCeDataReader dr)
		{
			User User = new User();
			User.DisplayName = dr.GetValue<string>("DisplayName");
			User.Email = dr.GetValue<string>("Email");
			User.FaceBookId = dr.GetValue<long>("FaceBookId");
			User.Id = dr.GetValue<int>("Id");
            User.EmailConfirmed = dr.GetValue<bool>("EmailConfirmed");
			User.PasswordHash = dr.GetValue<byte[]>("PasswordHash");
			User.PasswordSalt = dr.GetValue<byte[]>("PasswordSalt");
            User.ReferancedBy = dr.GetValue<string>("ReferencedBy");
            User.TwitterId = dr.GetValue<string>("TwitterId");
			return User;
		}

        internal static EmailConfirmCodes Populate_EmailConfirmCodes(SqlDataReader dr)
        {
            EmailConfirmCodes confirmCode = new EmailConfirmCodes();
            confirmCode.Email = dr.GetValue<string>("Email");
            confirmCode.Code = dr.GetValue<string>("Code");
            confirmCode.Created = dr.GetValue<DateTime>("Id");
            return confirmCode;
        }

        internal static EmailConfirmCodes Populate_EmailConfirmCodes(SqlCeDataReader dr)
        {
            EmailConfirmCodes confirmCode = new EmailConfirmCodes();
            confirmCode.Email = dr.GetValue<string>("Email");
            confirmCode.Code = dr.GetValue<string>("Code");
            confirmCode.Created = dr.GetValue<DateTime>("CreatedDate");
            return confirmCode;
        }

	    internal static SiteAdmin Populate_SiteAdmin(SqlDataReader dr)
	    {
	        SiteAdmin SiteAdmin = new SiteAdmin();
            SiteAdmin.Id = dr.GetValue<int>("Id");
            SiteAdmin.UserId = dr.GetValue<int>("UserId");
	        return SiteAdmin;
	    }

        internal static SiteAdmin Populate_SiteAdmin(SqlCeDataReader dr)
        {
            SiteAdmin SiteAdmin = new SiteAdmin();
            SiteAdmin.Id = dr.GetValue<int>("Id");
            SiteAdmin.UserId = dr.GetValue<int>("UserId");
            return SiteAdmin;
        }

	    internal static Permission Populate_permission(SqlDataReader dr)
	    {
	        Permission Permission = new Permission();
            Permission.Id = dr.GetValue<int>("Id");
            Permission.PermisstionName = dr.GetValue<string>("PermisstionName");
            Permission.ProjectId = dr.GetValue<int>("ProjectId");
            Permission.UserId = dr.GetValue<int>("UserId");
	        return Permission;
	    }

        internal static Permission Populate_permission(SqlCeDataReader dr)
        {
            Permission Permission = new Permission();
            Permission.Id = dr.GetValue<int>("Id");
            Permission.PermisstionName = dr.GetValue<string>("PermisstionName");
            Permission.ProjectId = dr.GetValue<int>("ProjectId");
            Permission.UserId = dr.GetValue<int>("UserId");
            return Permission;
        }
	}
}