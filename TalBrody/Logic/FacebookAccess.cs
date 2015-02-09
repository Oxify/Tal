using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using DotNetOpenAuth.ApplicationBlock.Facebook;

namespace TalBrody.Logic
{
    public class FacebookAccess
    {



        public class FacebookDetails
        {
            public FacebookGraph Graph { get; set; }
            public List<FacebookFriendsData> Friends { get; set; }

        }


        public static int RegisterUser(string AccessToken)
        {


            return -1;
        }

        public static FacebookDetails GetUserData(string AccessToken)
        {
            FacebookDetails Result = new FacebookDetails();
            Result.Graph = ReadGraph(AccessToken);
            Result.Friends = ReadFriends(AccessToken);

            return Result;

        }

        public static FacebookGraph ReadGraph(string AccessToken)
        {
            FacebookGraph Result = null;

            var request = WebRequest.Create("https://graph.facebook.com/me?access_token=" + Uri.EscapeDataString(AccessToken));
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    Result = FacebookGraph.Deserialize(responseStream);
                }
            }

            return Result;
        }

        public static List<FacebookFriendsData> ReadFriends(string AccessToken)
        {
            List<FacebookFriendsData> Result = new List<FacebookFriendsData>();

            string Next = "https://graph.facebook.com/me/friends?access_token=" + Uri.EscapeDataString(AccessToken);
            while (Next != null)
            {
                var request = WebRequest.Create(Next);
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, true);
                        string MyStr = streamReader.ReadToEnd();
                        var friends = FacebookFriends.Deserialize(MyStr);

                        foreach (var friend in friends.Data)
                        {
                            Result.Add(friend);
                        }
                        Next = friends.Paging.Next;
                    }
                }
            }
            return Result;
        }

    }
}