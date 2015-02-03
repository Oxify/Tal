using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace TalBrody.Common
{
    public class CommonFunction
    {
        public static byte[] CreateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            return salt;
        }

        public static byte[] Hash(string password, byte[] salt)
        {

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            return pbkdf2.GetBytes(20);
        }
    }
}