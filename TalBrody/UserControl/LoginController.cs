using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Oxify.DataLayer;
using Oxify.Entity;
using log4net;
using Mandrill;
using TalBrody.Models;

namespace TalBrody.UserControl
{
    public class LoginController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        public ActionResult RegisterOrLogin(string email)
        {
            if (!IsValidEmail(email))
            {
                return Json(new
                {
                    success = false,
                    error = "Invalid email"
                });
            }
            var user = new UserDal().FindUserByEmail(email);
            if (user != null)
            {
                log.Info(String.Format("Existing user {0}/{1} tried to register", user.Id, user.Email));
                return Json(new
                {
                    success = true,
                    redirectTo = "Login/Login"
                });
            }

            //users.CreateUser(email);
            return Json(new
            {
                success = true,
                redirectTo = "Login/CreateAccount?email=" + email // TODO - fill this in from the user's registration state
            });
        }

        [HttpPost]
        public ActionResult Register(string email, string password)
        {
            if (!IsValidEmail(email))
            {
                return Json(new
                {
                    success = false,
                    error = "Invalid email"
                });
            }

            if (!IsValidPassword(password))
            {
                return Json(new
                {
                    success = false,
                    error = "Invalid password"
                });
            }

            var users = new UserDal();
            if (users.FindUserByEmail(email) != null)
            {
                return Json(new
                {
                    success = false,
                    error = "Existing user"
                });
            }

            users.CreateUser(email, password);
            return Json(new
            {
                success = true
            });
        }

        public ActionResult CreateAccount(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return new HttpStatusCodeResult(404, "Missing email parameter");
            }

            var model = new CreateAccountModel {
                Email = email
            };
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TryLogin(string email, string password)
        {
            if (!new UserDal().CheckUser(email, password))
            {
                return Json(new{ success = false, error = "Wrong email or password"});
            }
            
            // TODO - Put a server-signed cookie in the session
            return Json(new
            {
                success = true
            });
        }

        /// <summary>
        /// http://stackoverflow.com/a/1374644/11236
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsValidEmail(string email)
        {
            // TODO - replace with System.ComponentModel.DataAnnotations.EmailAddressAttribute
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < 4)
            {
                return false;
            }

            return true;
        }
    }
}