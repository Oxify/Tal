﻿using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
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
            //OxifyParams.UpdateParam(OxifyParams.PARAM_DB_VERSION, "2", "2");
        }

		private void DBHandling1()
		{
			throw new NotImplementedException();
            //OxifyParams.UpdateParam(OxifyParams.PARAM_DB_VERSION, "1", 1);
        }

		private void DBHandling0()
		{
			try
			{
                CreateParams();
				CreatePerks();
				CreateProjects();
				CreateUsers();
				CreateFollowers();
			}
			catch (Exception ex)
			{
				Loging.InsertLog("DbHandling", "DBHandling0 Threw: " + ex.ToString());
				throw ex;
			}
		}

		private void CreateFollowers()
		{
            string Query = "CREATE TABLE [dbo].[Followers](	[Id] [int] IDENTITY(1,1) NOT NULL,	[ProjectId] [int] NOT NULL,	[UserId] [int] NOT NULL,";
            Query = Query + "CONSTRAINT [PK_Followers] PRIMARY KEY  ([Id] ASC)) ";
    		BdHandlinkDal dal = new BdHandlinkDal();
            dal.ExcuteDbCommand(Query);
		}

		private void CreateUsers()
		{
            string Query = "CREATE TABLE [dbo].[Users](	[Id] [int] IDENTITY(1,1) NOT NULL,[DisplayName] [nvarchar](100) NULL,[Email] [nvarchar](100) NULL,";
            Query = Query + "[FacebookId] [nvarchar](100) NULL,	[TwitterId] [nvarchar](100) NULL,[Password] [nvarchar](100) NULL,[ReferencedBy] [int] NULL, CONSTRAINT [PK_Users] PRIMARY KEY ";
            Query = Query + "([Id] ASC))";
			BdHandlinkDal dal = new BdHandlinkDal();
            dal.ExcuteDbCommand(Query);
		}

		private void CreateProjects()
		{
            string Query = "CREATE TABLE [dbo].[Projects]([id] [int] IDENTITY(1,1) NOT NULL,[DisplayName] [nvarchar](500) NULL,[ShortName] [nvarchar](100) NULL,";
            Query = Query + "[Description] [ntext] NULL,[LinkUrl] [nvarchar](100) NULL,[MovieUrl] [nvarchar](100) NULL, CONSTRAINT [PK_Projects] PRIMARY KEY (";
            Query = Query + "[id] ASC))";
			BdHandlinkDal dal = new BdHandlinkDal();
            dal.ExcuteDbCommand(Query);
		}

		private void CreatePerks()
		{
            string Query = "CREATE TABLE [dbo].[Perks]([PerkId] [int] IDENTITY(1,1) NOT NULL,[Title] [nvarchar](100) NULL,[Description] [nvarchar](500) NULL,[Cost] [int] NULL,";
            Query = Query + "[ProjectId] [int] NOT NULL,[ShowOrder] [int] NULL,CONSTRAINT [PK_Perks] PRIMARY KEY ([PerkId] ASC))";

			BdHandlinkDal dal = new BdHandlinkDal();
            dal.ExcuteDbCommand(Query);
		}

	    private void CreateParams()
	    {
	        string Query = "CREATE TABLE [Params] (";
	        Query += "[Id] int IDENTITY (1,1) NOT NULL, ";
	        Query += "[Name] nvarchar(50) NOT NULL, [Value] nvarchar(50) NOT NULL, [ValueInt] int NULL, CONSTRAINT [PK_Params] PRIMARY KEY ([Id])";

            BdHandlinkDal dal = new BdHandlinkDal();
            dal.ExcuteDbCommand(Query);
    
            OxifyParams.InsertParam(OxifyParams.PARAM_DB_VERSION, "1", 1);
	    }
	}
}