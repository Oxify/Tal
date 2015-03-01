using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace TalBrody.Util
{
    public class ImageRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string folder = requestContext.RouteData.Values["folder"] as string;
            string filename = requestContext.RouteData.Values["filename"] as string;
            string ext = requestContext.RouteData.Values["ext"] as string;

            if (string.IsNullOrEmpty(filename))
            {
                requestContext.HttpContext.Response.Clear();
                requestContext.HttpContext.Response.StatusCode = 404;
                requestContext.HttpContext.Response.End();
            }
            else
            {
                requestContext.HttpContext.Response.Clear();
                requestContext.HttpContext.Response.ContentType = GetContentType(requestContext.HttpContext.Request.Url.ToString());

                // find physical path to image here.  
                string filepath;
                if (folder != null) filepath = requestContext.HttpContext.Server.MapPath("~/Images/" + folder + "/" + filename + "." + ext);
                else filepath = requestContext.HttpContext.Server.MapPath("~/Images/" + filename + "." + ext);

                requestContext.HttpContext.Response.WriteFile(filepath);
                requestContext.HttpContext.Response.End();
            }
            return null;

        }
        private static string GetContentType(String path)
        {
            switch (System.IO.Path.GetExtension(path))
            {
                case ".bmp": return "Image/bmp";
                case ".gif": return "Image/gif";
                case ".jpg": return "Image/jpeg";
                case ".png": return "Image/png";
                default: break;
            }
            return "";
        }
    }
}