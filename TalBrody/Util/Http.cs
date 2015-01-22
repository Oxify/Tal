using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace TalBrody.Util
{
    public static class Http
    {
        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            using (var client = new WebClient())
            {
                return client.UploadValues(uri, pairs);
            }
        }
    }
}