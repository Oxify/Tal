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
		private int DbVerstion = 1;

        protected void Application_Start(object sender, EventArgs e)
        {
			
            // Set up a simple configuration that logs on the console.
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            string onAppHarbor = ConfigurationManager.AppSettings["OnAppHarbor"];
            log.Info("--------------------------------------");
            log.Info("------- STARTED APP, OnAppHarbor = " + onAppHarbor);
            log.Info("--------------------------------------");
			// cheking the db version and upgrade if needed
			OxifyParam oParm = OxifyParams.GetOxifyParam();
			if (oParm.DbVersion < DbVerstion)
			{
				DbHandling dbhandling = new DbHandling();
				dbhandling.UpgradeDbVerstion(oParm, DbVerstion);
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