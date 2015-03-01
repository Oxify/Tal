using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
//using AdventureWorksModel;

namespace TalBrody.Util
{
    public class ProjectRouteHandler : IRouteHandler
    {
        public  ProjectRouteHandler()
        { }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
           // AdventureWorksEntities awe = new AdventureWorksEntities();
            string cat = requestContext.RouteData.Values["ProjectId"] as string;
            int catid = 1; //awe.ProductCategories.Where(x => x.Name == cat).FirstOrDefault().ProductCategoryID;

            HttpContext.Current.Items["ProjectId"] = catid;
            return BuildManager.CreateInstanceFromVirtualPath("~/Products.aspx", typeof(Page)) as Page;
        }
    }
}