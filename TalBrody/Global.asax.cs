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

namespace TalBrody
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start(object sender, EventArgs e)
        {
            // Set up a simple configuration that logs on the console.
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

//            BasicConfigurator.Configure();
            log.Debug("Tetsing DEBUG LOG");
            log.Info("Testing INFO Log");
            log.Warn("Testing WARN Log");
            log.Error("Testing ERROR Log");
            Console.WriteLine("Testing Console.WriteLine");
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