using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
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

        /// <summary>
        /// Returns http://tal.apphb.com/ in production.
        /// </summary>
        public static string BaseUrl
        {
            get
            {
                var result = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                   HttpContext.Current.Request.ApplicationPath;

                if (Global.OnAppHarbor)
                {
                    // Remove any ports on appharbor (we're behind a proxy)
                    result = Regex.Replace(result, ":\\d+", "");
                }

                return result;
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // Setup Dependnecy Injection
            IOC.InitContainer();

            // Set up a simple configuration that logs on the console.
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            string onAppHarbor = ConfigurationManager.AppSettings["OnAppHarbor"];
            OnAppHarbor = onAppHarbor.ToLower().Equals("true");

            log.Info("--------------------------------------");
            log.Info("------- STARTED APP, OnAppHarbor = " + OnAppHarbor);
            log.Info("--------------------------------------");
            // cheking the db version and upgrade if needed
            int DbVersion = 0; 
            if (Params.CheckParamExists())
            {
                DbVersion = Params.GetParam(Params.PARAM_DB_VERSION).ValueInt ?? 0;
            }

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

        protected void Application_PostMapRequestHandler(object sender, EventArgs e)
        {
            // Make sure Application_Error gets WebMethod errors
            // http://stackoverflow.com/a/24222240/11236

            HttpContext context = HttpContext.Current;
            if (context.Handler is Page && !string.IsNullOrEmpty(context.Request.PathInfo))
            {
                string contentType = context.Request.ContentType.Split(';')[0];
                if (contentType.Equals("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.Filter = new PageMethodExceptionLogger(context.Response);
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex == null)
            {
                log.Error("Got error, but no exception...");
                return;
            }

            // Note: WebMethods don't reach this. See Application_PostMapRequestHandler
            log.Error("Caught exception", ex);
            if (ex is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}