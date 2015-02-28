using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody.Common
{
    public class SessionUtil
    {
        public static bool AddUserToSession(int UserId)
        {
            UserSession Usession = new UserSession();
            Usession.UserId = UserId;
            Usession.StartSession = DateTime.Now;
            Usession.PermissionList = Permissions.Get_All_Permission_By_UserId(UserId);
            UserDal dal = new UserDal();
            var user = dal.FindUserByid(UserId);
            if (user == null)
            {
                return false;
            }
            Usession.UserName = user.DisplayName;
            HttpContext.Current.Session.Add("Usession", Usession);
            return true;
        }
        public static byte[] CreateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            return salt;
        }

        public static UserSession GetUserSession()
        {
            UserSession usess = null;
            if (HttpContext.Current.Session["Usession"] != null)
                usess = (UserSession)HttpContext.Current.Session["Usession"];
            return usess;
        }

        public static byte[] Hash(string password, byte[] salt)
        {

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            return pbkdf2.GetBytes(20);
        }
    }
}