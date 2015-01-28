using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System.Diagnostics;
using System.Configuration;
using TalBrody.Logic;
using TalBrody.Entity;

namespace TalBrody
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private int CurrentDbVersion = 1;

        public static bool OnAppHarbor { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
			
            // Set up a simple configuration that logs on the console.
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            string onAppHarbor = ConfigurationManager.AppSettings["OnAppHarbor"];
            OnAppHarbor = onAppHarbor.ToLower().Equals("true");

            log.Info("--------------------------------------");
            log.Info("------- STARTED APP, OnAppHarbor = " + OnAppHarbor);
            log.Info("--------------------------------------");
			// cheking the db version and upgrade if needed
            int DbVersion = Params.GetParam(Params.PARAM_DB_VERSION).ValueInt ?? 0;

            log.Info("DB Version = " + DbVersion);
            if (DbVersion < CurrentDbVersion)
			{
				DbHandling dbhandling = new DbHandling();
                dbhandling.UpgradeDbVerstion(DbVersion, CurrentDbVersion);
			}
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}