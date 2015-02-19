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

			return new Follower
			{
                Id = dr.GetValue<int>("Id"),
			    DateCreated = dr.GetValue<DateTime>("DateCreated"),
                ProjectId = dr.GetValue<int>("ProjectId"),
                UserId = dr.GetValue<int>("UserId"),
			   
			};
		}

		internal static Follower Populate_Follower(SqlDataReader dr)
		{
			return new Follower
			{
                Id = dr.GetValue<int>("Id"),
                DateCreated = dr.GetValue<DateTime>("DateCreated"),
                ProjectId = dr.GetValue<int>("ProjectId"),
                UserId = dr.GetValue<int>("UserId"),
			};
		}

		internal static Perks Populate_Perks(SqlCeDataReader dr)
		{

			return new Perks
			{
			    Cost = dr.GetValue<int>("Cost"),
			    Description = dr.GetValue<string>("Description"),
			    PerkId = dr.GetValue<int>("PerkId"),
			    ProjectId = dr.GetValue<int>("ProjectId"),
			    ShowOrder = dr.GetValue<int>("ShowOrder"),
			    Title = dr.GetValue<string>("Title")
			};
		}

		internal static Perks Populate_Perks(SqlDataReader dr)
		{

			return new Perks
			{
			    Cost = dr.GetValue<int>("Cost"),
			    Description = dr.GetValue<string>("Description"),
			    PerkId = dr.GetValue<int>("PerkId"),
			    ProjectId = dr.GetValue<int>("ProjectId"),
			    ShowOrder = dr.GetValue<int>("ShowOrder"),
			    Title = dr.GetValue<string>("Title")
			};
		}

		internal static Project Populate_Project(SqlCeDataReader dr)
		{

			return new Project
			{
			    Description = dr.GetValue<string>("Description"),
			    DisplayName = dr.GetValue<string>("DisplayName"),
			    id = dr.GetValue<int>("id"),
			    LinkUrl = dr.GetValue<string>("LinkUrl"),
			    MovieUrl = dr.GetValue<string>("MovieUrl"),
			    ShortName = dr.GetValue<string>("ShortName")
			};
		}

		internal static Project Populate_Project(SqlDataReader dr)
		{

			return new Project
			{
			    Description = dr.GetValue<string>("Description"),
			    DisplayName = dr.GetValue<string>("DisplayName"),
			    id = dr.GetValue<int>("id"),
			    LinkUrl = dr.GetValue<string>("LinkUrl"),
			    MovieUrl = dr.GetValue<string>("MovieUrl"),
			    ShortName = dr.GetValue<string>("ShortName")
			};
		}

		internal static Param Populate_Params(SqlDataReader dr)
		{
			return new Param
			{
			    Name = dr.GetValue<string>("Name"),
			    Value = dr.GetValue<string>("Value"),
			    ValueInt = dr.GetInt32(dr.GetOrdinal("ValueInt"))
			};
		}

		internal static Param Populate_Params(SqlCeDataReader dr)
		{

			return new Param
			{
			    Name = dr.GetValue<string>("Name"),
			    Value = dr.GetValue<string>("Value"),
			    ValueInt = dr.GetInt32(dr.GetOrdinal("ValueInt"))
			};
		}

		internal static ProjectDetails Populate_projectDetails(SqlDataReader dr)
		{
			return new ProjectDetails
			{
			    FieldId = dr.GetValue<int>("FieldId"),
			    FontSize = dr.GetValue<int>("FontSize"),
			    Id = dr.GetValue<int>("Id"),
			    LangId = dr.GetValue<int>("LangId"),
			    ProjectId = dr.GetValue<int>("ProjectId"),
			    Text = dr.GetValue<string>("Text")
			};
		}

		internal static ProjectDetails Populate_projectDetails(SqlCeDataReader dr)
		{
			return new ProjectDetails
			{
			    FieldId = dr.GetValue<int>("FieldId"),
			    FontSize = dr.GetValue<int>("FontSize"),
			    Id = dr.GetValue<int>("Id"),
			    LangId = dr.GetValue<int>("LangId"),
			    ProjectId = dr.GetValue<int>("ProjectId"),
			    Text = dr.GetValue<string>("Text")
			};
		}

		internal static User Populate_User(SqlDataReader dr)
		{
			return new User
			{
			    DisplayName = dr.GetValue<string>("DisplayName"),
			    Email = dr.GetValue<string>("Email"),
			    FacebookId = dr.GetValue<long>("FacebookId"),
			    Id = dr.GetValue<int>("Id"),
			    EmailConfirmed = dr.GetValue<bool>("EmailConfirmed"),
			    PasswordHash = dr.GetValue<byte[]>("PasswordHash"),
			    PasswordSalt = dr.GetValue<byte[]>("PasswordSalt"),
			    ReferredBy = dr.GetValue<string>("ReferredBy"),
			    TwitterId = dr.GetValue<string>("TwitterId"),
			    ReferralCode = dr.GetValue<string>("ReferralCode")
			};
		}

        internal static User Populate_User(SqlCeDataReader dr)
		{
			return new User
			{
			    DisplayName = dr.GetValue<string>("DisplayName"),
			    Email = dr.GetValue<string>("Email"),
			    FacebookId = dr.GetValue<long>("FacebookId"),
			    Id = dr.GetValue<int>("Id"),
			    EmailConfirmed = dr.GetValue<bool>("EmailConfirmed"),
			    PasswordHash = dr.GetValue<byte[]>("PasswordHash"),
			    PasswordSalt = dr.GetValue<byte[]>("PasswordSalt"),
			    ReferredBy = dr.GetValue<string>("ReferredBy"),
			    TwitterId = dr.GetValue<string>("TwitterId"),
			    ReferralCode = dr.GetValue<string>("ReferralCode")
			};
		}

        internal static EmailConfirmCodes Populate_EmailConfirmCodes(SqlDataReader dr)
        {
            return new EmailConfirmCodes
            {
                Email = dr.GetValue<string>("Email"),
                Code = dr.GetValue<string>("Code"),
                Created = dr.GetValue<DateTime>("CreatedDate")
            };
        }

        internal static EmailConfirmCodes Populate_EmailConfirmCodes(SqlCeDataReader dr)
        {
            return new EmailConfirmCodes
            {
                Email = dr.GetValue<string>("Email"),
                Code = dr.GetValue<string>("Code"),
                Created = dr.GetValue<DateTime>("CreatedDate")
            };
        }

	    internal static SiteAdmin Populate_SiteAdmin(SqlDataReader dr)
	    {
	        return new SiteAdmin
	        {
	            Id = dr.GetValue<int>("Id"),
                UserId = dr.GetValue<int>("UserId")
	        };
	    }

        internal static SiteAdmin Populate_SiteAdmin(SqlCeDataReader dr)
        {
            return new SiteAdmin {
                Id = dr.GetValue<int>("Id"), 
                UserId = dr.GetValue<int>("UserId")
            };
        }

	    internal static Permission Populate_permission(SqlDataReader dr)
	    {
	        return new Permission
	        {
	            Id = dr.GetValue<int>("Id"),
	            PermisstionId = dr.GetValue<int>("PermisstionId"),
	            ProjectId = dr.GetValue<int>("ProjectId"),
	            UserId = dr.GetValue<int>("UserId")
	        };
	    }

        internal static Permission Populate_permission(SqlCeDataReader dr)
        {
            return new Permission
            {
                Id = dr.GetValue<int>("Id"),
                PermisstionId = dr.GetValue<int>("PermisstionId"),
                ProjectId = dr.GetValue<int>("ProjectId"),
                UserId = dr.GetValue<int>("UserId")
            };
        }
	}
}