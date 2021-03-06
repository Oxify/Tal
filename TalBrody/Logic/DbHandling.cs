﻿using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.Common;
using TalBrody.DataLayer;
using TalBrody.Entity;
using TalBrody.Util;


namespace TalBrody.Logic
{
    public class DbHandling
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool UpgradeDbVerstion(int CurrentVersion, int DestinationDbVersion)
        {
            bool Result = false;

            try
            {
                while (CurrentVersion <= DestinationDbVersion)
                {
                    log.Info("Upgrading DB from version " + CurrentVersion + " to version " + DestinationDbVersion);
                    switch (CurrentVersion)
                    {
                        case 0:
                            DBHandling0();
                            break;

                        case 1:
                            DBHandling1();
                            break;

                        case 2:
                            DBHandling2();
                            break;

                        default:
                            break;
                    }
                    CurrentVersion++;

                }
            }
            catch (Exception ex)
            {
                Loging.InsertLog("DbHandling", "UpgradeDbVerstion Threw: " + ex);
                throw;
            }
            return Result;
        }

        private void DBHandling2()
        {
            throw new NotImplementedException();
            //Params.UpdateParam(Params.PARAM_DB_VERSION, "2", "2");
        }

        private void DBHandling1()
        {
            //throw new NotImplementedException();
            //Params.UpdateParam(Params.PARAM_DB_VERSION, "1", 1);
        }

        private void DBHandling0()
        {
            try
            {
                CreateFriends();
                CreatePerks();
                CreateProjects();
                CreateUsers();
                CreateFollowers();
                CreateProjectDetails();
                CreateSiteAdmin();
                CreateEmailConfirmCodes();
                InsertSiteAdminAndUser();
                CreatePermissions();

                // create params needs to be last! 
                CreateParams();
                // create params is last!
            }
            catch (Exception ex)
            {
                Loging.InsertLog("DbHandling", "DBHandling0 Threw: " + ex.ToString());
                throw;
            }
        }

        private void CreateFriends()
        {
            DropIfExists("Friends");

            string Query = "CREATE TABLE [Friends] (  [Id] int IDENTITY (1,1) NOT NULL" +
                            ", [Userid  ] int NOT NULL, [FriendId ] nvarchar(100) NOT NULL,[platform] int null" +
                            ", [createdate ] datetime DEFAULT getdate()  NULL,CONSTRAINT [PK_Friends] PRIMARY KEY ([Id]));";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);

        }

        private void CreateEmailConfirmCodes()
        {
            DropIfExists("EmailConfirmCodes");

            string Query = "CREATE TABLE [EmailConfirmCodes]([Code] [nvarchar](50) NOT NULL, [Email] [nvarchar](100) NOT NULL," +
                           "[CreatedDate] [DateTime] default GETDATE())";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreatePermissions()
        {
            DropIfExists("Permissions");

            string Query = "CREATE TABLE [Permissions]([Id] [int] IDENTITY(1,1) NOT NULL,[UserId] [int] NULL," +
                           "[ProjectId] [int] NULL,[PermisstionId] int NULL, [CreatedDate] datetime DEFAULT getdate() NULL ,CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id]))";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void InsertSiteAdminAndUser()
        {
            int UserId = 0;
            var salt = SessionUtil.CreateSalt();
            var hashed = SessionUtil.Hash("1ziv@tzoran", salt);
            UserDal dal = new UserDal();
            string referralCode = UUIDCreator.Create(8);
            UserId = dal.CreateUser("zivverb@hotmail.com", "1ziv@tzoran", hashed, salt, referralCode);
            int userId = UserId;
            SiteAdmin sadmin = new SiteAdmin {UserId = userId};
            SiteAdmins.InsertSiteAdmin(sadmin);

            int userId3 = 0;
            var salt1 = SessionUtil.CreateSalt();
            var hashed1 = SessionUtil.Hash("1ortal@raz", salt1);
            UserDal dal1 = new UserDal();
            string referralCode1 = UUIDCreator.Create(8);
            userId3 = dal1.CreateUser("ortal@oxify.co", "1ortal@raz", hashed1, salt1, referralCode1);
            int userId1 = userId3;
            SiteAdmin sadmin1 = new SiteAdmin {UserId = userId1};
            SiteAdmins.InsertSiteAdmin(sadmin1);

            int userId4 = 0;
            var salt2 = SessionUtil.CreateSalt();
            var hashed2 = SessionUtil.Hash("1ron@gross", salt2);
            UserDal dal2 = new UserDal();
            string referralCode2 = UUIDCreator.Create(8);
            userId4 = dal2.CreateUser("ron@oxify.co", "1ron@gross", hashed2, salt2, referralCode2);
            int userId2 = userId4;
            SiteAdmin sadmin2 = new SiteAdmin {UserId = userId2};
            SiteAdmins.InsertSiteAdmin(sadmin2);
        }

        private void CreateSiteAdmin()
        {
            DropIfExists("SiteAdmin");

            string Query = "CREATE TABLE [SiteAdmin]([Id] [int] IDENTITY(1,1) NOT NULL,[UserId] [int] NULL, [CreatedDate] datetime DEFAULT getdate() NULL) ";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateProjectDetails()
        {
            DropIfExists("ProjectDetails");

            string Query = "CREATE TABLE [ProjectDetails](	[Id] [int] IDENTITY(1,1) NOT NULL,[ProjectId] [int] NOT NULL,[FieldId] [int] NOT NULL,";
            Query = Query + "[LangId] [int] NOT NULL,[Text] [nvarchar](4000) NULL,[FontSize] [int] NOT NULL, [CreatedDate] datetime DEFAULT getdate() NULL, CONSTRAINT [PK_ProjectDetails] PRIMARY KEY  (";
            Query = Query + "[Id]))";

            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateFollowers()
        {
            DropIfExists("Followers");

            string Query = "CREATE TABLE [Followers](	[Id] [int] IDENTITY(1,1) NOT NULL,	[ProjectId] [int] NOT NULL,	[UserId] [int] NOT NULL, [CreatedDate] datetime DEFAULT getdate() NULL,[FollowerGuid] [nvarchar](100) NULL,FollowerCount [int] DEFAULT 0 NULL,[ReferByUserId] int NULL,";
            Query = Query + "CONSTRAINT [PK_Followers] PRIMARY KEY  ([Id] )) ";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateUsers()
        {
            DropIfExists("Users");

            string Query = " CREATE TABLE [Users]([Id] [int] IDENTITY(1,1) NOT NULL,[DisplayName] [nvarchar](100) NULL,";
            Query = Query + "[Email] [nvarchar](100) NULL,[FacebookId] [nvarchar](100) NULL, [FacebookAccessToken] [nvarchar](1000) NULL, ";
            Query = Query + "[TwitterId] [nvarchar](100) NULL,[TwitterToken] [nvarchar](1000) NULL, [LastLogin] [DateTime] default GETDATE(),";
            Query = Query + "[TwitterSecret] [nvarchar](1000) NULL, [TwitterAccessToken] [nvarchar](1000) NULL, [ReferredBy] [int] NULL,";
            Query = Query + "[PasswordSalt] [binary](16) NULL,[PasswordHash] [binary](20) NULL,[EmailConfirmed] [bit] NULL," +
                    "[Birthday] [DateTime], [ValidPassword] [bit], [DateCreated] [DateTime] default GETDATE()," +
                    "[ReferralCode] [nvarchar](100)," +
                    "CONSTRAINT [PK_Users] PRIMARY KEY  ([Id]))";

            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateProjects()
        {
            DropIfExists("Projects");

            string Query = "CREATE TABLE [Projects]([id] [int] IDENTITY(1,1) NOT NULL,[DisplayName] [nvarchar](500) NULL,[ShortName] [nvarchar](100) NULL,";
            Query = Query + "[Description] [ntext] NULL,[LinkUrl] [nvarchar](100) NULL,[MovieUrl] [nvarchar](100) NULL, [CreatedDate] datetime DEFAULT getdate() NULL, CONSTRAINT [PK_Projects] PRIMARY KEY (";
            Query = Query + "[id] ))";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreatePerks()
        {
            DropIfExists("Perks");

            string Query = "CREATE TABLE [Perks]([PerkId] [int] IDENTITY(1,1) NOT NULL,[Title] [nvarchar](100) NULL,[Description] [nvarchar](500) NULL,[Cost] [int] NULL,";
            Query = Query + "[ProjectId] [int] NOT NULL,[ShowOrder] [int] NULL, [CreatedDate] datetime DEFAULT getdate() NULL,CONSTRAINT [PK_Perks] PRIMARY KEY ([PerkId]))";

            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateParams()
        {
            DropIfExists("Params");

            string Query = "CREATE TABLE [Params] (";
            Query += "[Id] int IDENTITY (1,1) NOT NULL, ";
            Query += "[Name] nvarchar(50) NOT NULL, [Value] nvarchar(50) NOT NULL, [ValueInt] int NULL, [CreatedDate] datetime DEFAULT getdate() NULL, CONSTRAINT [PK_Params] PRIMARY KEY ([Id]))";

            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);

            Params.InsertParam(Params.PARAM_DB_VERSION, "1", 1);
        }

        private void DropIfExists(string table)
        {
            // This doesn't not work on SQL CE
            // http://stackoverflow.com/a/14290099/11236

            var dal = new BdHandlingDal();
            if (dal.CheckTableExists(table))
            {
                log.Warn("Dropping table " + table);

                var cmd = string.Format("drop table {0};", table);
                dal.ExcuteDbCommand(cmd);
            }
        }
    }
}