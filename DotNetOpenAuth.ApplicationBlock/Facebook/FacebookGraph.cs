//-----------------------------------------------------------------------
// <copyright file="FacebookGraph.cs" company="Outercurve Foundation">
//     Copyright (c) Outercurve Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Security.Cryptography.X509Certificates;

namespace DotNetOpenAuth.ApplicationBlock.Facebook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;


    [DataContract]
    public class FacebookFriendsData
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "id")]
        public long Id { get; set; }

    }

    [DataContract]
    public class FacebookFriendsPaging
    {
        [DataMember(Name="next")]
        public string Next { get; set; }
        [DataMember(Name="previous")]
        public string Previous { get; set; }
    }

    [DataContract]
    public class FacebookFriendsSummary
    {
        [DataMember(Name = "total_count")]
        public long TotalCount { get; set; }

    }

    [DataContract]
    public class FacebookFriends
    {
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(FacebookFriends));

        [DataMember(Name = "data")]
        public List<FacebookFriendsData> Data { get; set; }

        [DataMember(Name = "paging")]
        public FacebookFriendsPaging Paging { get; set; }

        [DataMember(Name = "summary")]
        public FacebookFriendsSummary Summary { get; set; }

        public static FacebookFriends Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException("json");
            }

            return Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        }

        public static FacebookFriends Deserialize(Stream jsonStream)
        {
            if (jsonStream == null)
            {
                throw new ArgumentNullException("jsonStream");
            }

            return (FacebookFriends)jsonSerializer.ReadObject(jsonStream);
        }
    }
}
