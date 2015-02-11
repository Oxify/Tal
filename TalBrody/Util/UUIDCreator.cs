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
            if (length > 8)
            {
                throw new ArgumentException("I'm lazy, length > 8 not yet supported (GUIDs look like 12345678-something-something");
            }
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}