using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TalBrody.Common
{
    public class CommonFunction
    {
        public static void ShowAlertMessage(Page page,string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "EPG Edit", "<script language=\"javaScript\">" + "alert('" + message + "');" + "</script>");
        }
    }
}