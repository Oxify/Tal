using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Util
{
    public class UUIDCreator
    {
        public static string Create(int length)
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            if (length == -1)
                return GuidString;
            else
                return GuidString.Substring(0, length);
        }
    }
}