using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TalBrody.UserControl
{
    public class LoginController : Controller
    {
        // GET: Default
        [HttpPost]
        public ActionResult Register(string email)
        {
            return new RedirectResult("http://success.org/");
        }
    }
}