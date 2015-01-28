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

		public bool UpgradeDbVerstion(OxifyParam OParam, int DestinationDbVersion)
		{
			bool Result = false;
			int CurrentStatus = OParam.DbVersion;

			try
			{
				while (CurrentStatus <= DestinationDbVersion)
				{
                    log.Info("Upgrading DB from version " + CurrentStatus + " to version " + DestinationDbVersion);
					switch (CurrentStatus)
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
					CurrentStatus++;
					OParam.DbVersion = CurrentStatus;
					OxifyParams.UpdateOxifyParam(OParam);
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
		}

		private void DBHandling1()
		{
			throw new NotImplementedException();
		}

		private void DBHandling0()
		{
			try
			{
				CreatePerks();
				CreateProjects();
				CreateUsers();
				CreateFollwers();
			}
			catch (Exception ex)
			{
				Loging.InsertLog("DbHandling", "DBHandling0 Threw: " + ex.ToString());
				throw ex;
			}
		}

		private void CreateFollwers()
		{
			string Qwery = "CREATE TABLE [dbo].[Follwers](	[Id] [int] IDENTITY(1,1) NOT NULL,	[ProjectId] [int] NULL,	[UserId] [int] NULL,";
			Qwery = Qwery +"CONSTRAINT [PK_Follwers] PRIMARY KEY CLUSTERED (	[Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ";
			Qwery = Qwery + "OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
			BdHandlinkDal dal = new BdHandlinkDal();
			dal.ExcuteDbCommand(Qwery);
		}

		private void CreateUsers()
		{
			string Qwery = "CREATE TABLE [dbo].[Users](	[Id] [int] IDENTITY(1,1) NOT NULL,[DisplayName] [nvarchar](100) NULL,[Email] [nvarchar](100) NULL,";
			Qwery = Qwery + "[FacebookId] [nvarchar](100) NULL,	[TwitterId] [nvarchar](100) NULL,[Password] [nvarchar](100) NULL,[ReferencedBy] [int] NULL, CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ";
			Qwery = Qwery + "([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
			BdHandlinkDal dal = new BdHandlinkDal();
			dal.ExcuteDbCommand(Qwery);
		}

		private void CreateProjects()
		{
			string Qwery = "CREATE TABLE [dbo].[Projects]([id] [int] IDENTITY(1,1) NOT NULL,[DisplayName] [nvarchar](500) NULL,[ShortName] [nvarchar](100) NULL,";
			Qwery = Qwery + "[Description] [ntext] NULL,[LinkUrl] [nvarchar](100) NULL,[nvarchar] [nvarchar](100) NULL, CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED (";
			Qwery = Qwery + "[id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
			Qwery = Qwery + ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";
			BdHandlinkDal dal = new BdHandlinkDal();
			dal.ExcuteDbCommand(Qwery);
		}

		private void CreatePerks()
		{
			string Qwery = "CREATE TABLE [dbo].[Perks]([PerkId] [int] IDENTITY(1,1) NOT NULL,[Title] [nvarchar](100) NULL,[Description] [nvarchar](500) NULL,[Cost] [int] NULL,";
			Qwery = Qwery + "[ProjectId] [int] NULL,[ShowOrder] [int] NULL,CONSTRAINT [PK_Perks] PRIMARY KEY CLUSTERED ([PerkId] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
			Qwery = Qwery + ") ON [PRIMARY]";

			BdHandlinkDal dal = new BdHandlinkDal();
			dal.ExcuteDbCommand(Qwery);
		}
	}
}