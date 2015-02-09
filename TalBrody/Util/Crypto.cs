using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace TalBrody.Util
{
    public class Crypto
    {
        private string SECRET = "M!HALfh1NC&1pAHNLDzgABASDKU";

        // Sign a string using symmetric cryptography 
        public string SignSymmetric(string text)
        {
            SHA1 sha1 = SHA1Managed.Create();
            var bytes = Encoding.UTF8.GetBytes(SECRET + text);
            var hashBytes = sha1.ComputeHash(bytes);
            var hashStr = Convert.ToBase64String(hashBytes);
            // var hashStr = Encoding.UTF8.GetString(hashBytes);
            return string.Format("({0},{1})", hashStr, text);
        }

        public bool VerifySignatureSymmetric(string signedText)
        {
            var match = Regex.Match(signedText, @"\((.*?),(.*)\)");
            if (!match.Success)
            {
                return false;
            }
            var text = match.Groups[2].Value;

            var signedAgain = SignSymmetric(text);
            return signedAgain == signedText;
        }
    }
}