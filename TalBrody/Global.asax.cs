﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Castle.MicroKernel.Registration;
using log4net;
using log4net.Config;
using System.Configuration;
using TalBrody.Logic;
using TalBrody.Util;
using System.Web.Routing;

namespace TalBrody
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int CurrentDbVersion = 1;

        public static bool OnAppHarbor { get; private set; }
        public static string FacebookId { get; private set; }
        public static string BaseUrl { get; private set; }
        public static bool OnProduction { get; private set; }
        public static bool OnTest { get; private set; }

        public static void RegisterRoute(RouteCollection routers)
        {
            //routers.Ignore("{*alljs}", new { alljs = @".*\.js(/.*)?" });
            //routers.Ignore("{*allpng}", new { allpng = @".*\.png(/.*)?" });
            //routers.Ignore("{*allcss}", new { allcss = @".*\.css(/.*)?" });
            routers.Ignore("Css/{*pathInfo}");
            routers.Ignore("{resource}.axd/{*pathInfo}");
            // routers.Add("Images", new Route("Images/{filename}.{ext}", new ImageRouteHandler()));
            routers.MapPageRoute("", "p", "~/RockAroundTheClock.aspx");
            routers.MapPageRoute("", "p/m1fj", "~/RockAroundTheClock.aspx");
            routers.MapPageRoute("", "p/g8bk", "~/RockAroundTheClock.aspx");
            routers.MapPageRoute("", "p/g8bk/Rock", "~/RockAroundTheClock.aspx");
            routers.MapPageRoute("", "p/g8bk/Rock/share", "~/Share.aspx");
            routers.MapPageRoute("", "p/m1fj/toys", "~/RockAroundTheClock.aspx");
            routers.MapPageRoute("", "p/m1fj/toys/share", "~/Share.aspx");
            routers.MapPageRoute("", "tos", "~/TermsOfService.aspx");
            routers.MapPageRoute("", "privacy", "~/PrivacyPolicy.aspx");
            routers.MapPageRoute("", "about", "~/About.aspx");
            routers.MapPageRoute("", "contact", "~/ContactUs.aspx");
            routers.MapPageRoute("", "fAQ", "~/FAQ.aspx");
            //routers.MapPageRoute("", "Blog", "blog.oxify.co");
            routers.MapPageRoute("", "Edit", "~/EditProject.aspx");
            routers.MapPageRoute("Edit", "Edit{ProjectId}", "~/EditProject.aspx");
            routers.MapPageRoute("", "a", "~/AdminDashBord.aspx");
            routers.MapPageRoute("", "confirm", "~/ConfirmEmail.aspx");
        }


        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoute(RouteTable.Routes);
            //     MapPageRoute 

            // Setup Dependnecy Injection
            IOC.InitContainer(container =>
            {
                container.Register(
                    Component.For<IResourceResolver>()
                        .Instance(new FileSystemResourceResolver(HttpContext.Current.Server.MapPath("~/"))));
            });


            // ConfigurationManager.AppSettings.Add("Global.BaseUrl", CalcBaseUrl()); // or SiteUrl

            // Set up a simple configuration that logs on the console.
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            string onAppHarbor = ConfigurationManager.AppSettings["OnAppHarbor"];
            OnAppHarbor = onAppHarbor.ToLower().Equals("true");

            string facebookId = ConfigurationManager.AppSettings["Facebookid"];
            FacebookId = facebookId;

            string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            BaseUrl = baseUrl;

            string EnvironmentType = ConfigurationManager.AppSettings["EnvironmentType"].ToLower();
            if (EnvironmentType == "production")
            {
                OnProduction = true;
            }
            else
            {
                OnProduction = false;
            }
            if (EnvironmentType == "Test")
            {
                OnTest = true;
            }
            else
            {
                OnTest = false;
            }
            log.Info("--------------------------------------");
            log.Info("------------ STARTED APP! ------------");
            log.Info("OnAppHarbor = " + OnAppHarbor);
            log.Info("BaseUrl = " + BaseUrl);
            log.Info("FacebookId = " + FacebookId);
            log.Info("OnProduction = " + OnProduction);
            log.Info("OnTest = " + OnTest);
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

        private string CalcBaseUrl()
        {
            var result = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                   HttpContext.Current.Request.ApplicationPath;

            if (OnAppHarbor)
            {
                // Remove any ports on appharbor (we're behind a proxy)
                result = Regex.Replace(result, ":\\d+", "");
            }

            return result;
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
            //  log.Error("Caught exception", ex );
            log.ErrorFormat("My {0} message: {1}", "Caught exception", ex.StackTrace);
            // HttpContext.Current.Response.Write(string.Format("My {0} message: {1}", "Caught exception", ex.StackTrace));
            if (ex is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                Server.Transfer("ErrorPage.html?handler=Application_Error%20-%20Global.asax", true);
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