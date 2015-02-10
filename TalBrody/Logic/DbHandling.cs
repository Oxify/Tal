using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                Loging.InsertLog("DbHandling", "UpgradeDbVerstion Threw: " + ex.ToString());
                throw ex;
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
                CreatePerks();
                CreateProjects();
                CreateUsers();
                CreateFollowers();
                CreateProjectDetails();
                CreateSiteAdmin();
                CreateEmailConfirmCodes();
                InsertSiteAdminAndUser();
                Permission();

                // create params needs to be last! 
                CreateParams();
                // create params is last!
            }
            catch (Exception ex)
            {
                Loging.InsertLog("DbHandling", "DBHandling0 Threw: " + ex.ToString());
                throw ex;
            }
        }

        private void CreateEmailConfirmCodes()
        {
            string Query = "CREATE TABLE [EmailConfirmCodes]([Code] [nvarchar](50) NOT NULL, [Email] [nvarchar](100) NOT NULL," +
                           "[CreatedDate] [DateTime] default GETDATE())";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void Permission()
        {
            string Query = "CREATE TABLE [Permissions]([Id] [int] IDENTITY(1,1) NOT NULL,[UserId] [int] NULL," +
                           "[ProjectId] [int] NULL,[PermisstionName] [nvarchar](50) NULL ,CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id]))";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void InsertSiteAdminAndUser()
        {
            int userId = Users.CreateUser("zivverb@hotmail.com", "1ziv@tzoran");
            SiteAdmin sadmin = new SiteAdmin {UserId = userId};
            SiteAdmins.InsertSiteAdmin(sadmin);

            int userId1 = Users.CreateUser("ortalr@gmail.com", "1ortal@raz");
            SiteAdmin sadmin1 = new SiteAdmin {UserId = userId1};
            SiteAdmins.InsertSiteAdmin(sadmin1);

            int userId2 = Users.CreateUser("ron.gross@gmail.com", "1ron@gross");
            SiteAdmin sadmin2 = new SiteAdmin {UserId = userId2};
            SiteAdmins.InsertSiteAdmin(sadmin2);
        }

        private void CreateSiteAdmin()
        {
            string Query = "CREATE TABLE [SiteAdmin]([Id] [int] IDENTITY(1,1) NOT NULL,[UserId] [int] NULL) ";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateProjectDetails()
        {
            string Query = "CREATE TABLE [ProjectDetails](	[Id] [int] IDENTITY(1,1) NOT NULL,[ProjectId] [int] NOT NULL,[FieldId] [int] NOT NULL,";
            Query = Query + "[LangId] [int] NOT NULL,[Text] [nvarchar](4000) NULL,[FontSize] [int] NOT NULL, CONSTRAINT [PK_ProjectDetails] PRIMARY KEY  (";
            Query = Query + "[Id]))";

            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateFollowers()
        {
            string Query = "CREATE TABLE [Followers](	[Id] [int] IDENTITY(1,1) NOT NULL,	[ProjectId] [int] NOT NULL,	[UserId] [int] NOT NULL,";
            Query = Query + "CONSTRAINT [PK_Followers] PRIMARY KEY  ([Id] )) ";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateUsers()
        {

            string Query = " CREATE TABLE [Users]([Id] [int] IDENTITY(1,1) NOT NULL,[DisplayName] [nvarchar](100) NULL,";
            Query = Query + "[Email] [nvarchar](100) NULL,[FacebookId] [nvarchar](100) NULL,[TwitterId] [nvarchar](100) NULL,[ReferencedBy] [int] NULL,";
            Query = Query + "[PasswordSalt] [binary](16) NULL,[PasswordHash] [binary](20) NULL,[EmailConfirmed] [bit] NULL,CONSTRAINT [PK_Users] PRIMARY KEY  (";
            Query = Query + "[Id]))";
     

            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateProjects()
        {
            string Query = "CREATE TABLE [Projects]([id] [int] IDENTITY(1,1) NOT NULL,[DisplayName] [nvarchar](500) NULL,[ShortName] [nvarchar](100) NULL,";
            Query = Query + "[Description] [ntext] NULL,[LinkUrl] [nvarchar](100) NULL,[MovieUrl] [nvarchar](100) NULL, CONSTRAINT [PK_Projects] PRIMARY KEY (";
            Query = Query + "[id] ))";
            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreatePerks()
        {
            string Query = "CREATE TABLE [Perks]([PerkId] [int] IDENTITY(1,1) NOT NULL,[Title] [nvarchar](100) NULL,[Description] [nvarchar](500) NULL,[Cost] [int] NULL,";
            Query = Query + "[ProjectId] [int] NOT NULL,[ShowOrder] [int] NULL,CONSTRAINT [PK_Perks] PRIMARY KEY ([PerkId]))";

            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);
        }

        private void CreateParams()
        {
            string Query = "CREATE TABLE [Params] (";
            Query += "[Id] int IDENTITY (1,1) NOT NULL, ";
            Query += "[Name] nvarchar(50) NOT NULL, [Value] nvarchar(50) NOT NULL, [ValueInt] int NULL, CONSTRAINT [PK_Params] PRIMARY KEY ([Id]))";

            BdHandlingDal dal = new BdHandlingDal();
            dal.ExcuteDbCommand(Query);

            Params.InsertParam(Params.PARAM_DB_VERSION, "1", 1);
        }
    }
}