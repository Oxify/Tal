using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using DotNetOpenAuth.ApplicationBlock.Facebook;
using TalBrody.Entity;
using TalBrody.Util;

namespace TalBrody.Logic
{
    public class FacebookAccess
    {
        private static string ClientIdentifier;
        private static string ClientSecret;

        static FacebookAccess()
        {
            ClientIdentifier = ConfigurationManager.AppSettings["facebookAppID"];
            ClientSecret = ConfigurationManager.AppSettings["facebookAppSecret"];

        }


        public class FacebookDetails
        {
            public string AccessToken { get; set; }
            public FacebookGraph Graph { get; set; }
            public List<FacebookFriendsData> Friends { get; set; }

        }


        public static Entity.User RegisterUser(string AccessToken)
        {
            var data = GetUserData(AccessToken);
            Entity.User id = null;
            if (data.Graph.EMail != null)
                id = Users.FindUserByEmail(data.Graph.EMail);

            if (id == null)
            {
                // no id, new user!
                id = new User();
                PopulateUser(data, ref id);
                id.Id = Users.CreateUserWithoutPassword(id);
                if (id.Email != null)
                {
                    var code = Users.GenerateUserRegistrationCode(id);
                    new Email().SendRegistrationEmail(id, code);
                }
            }
            else
            {
                // user already registered somehow, let's update the DB
                PopulateUser(data, ref id);
                Users.UpdateUser(id);
            }

            return id;
        }

        private static void PopulateUser(FacebookDetails details, ref Entity.User user)
        {
            user.FacebookAccessToken = details.AccessToken;
            user.FacebookId = details.Graph.Id;
            user.Email = details.Graph.EMail;
            user.DisplayName = details.Graph.Name;
            // TODO add referece by support by cookies here
            // user.ReferredBy = 
            //TODO fix birthday
            //user.Birthday = details.Graph.Birthday;

        }
        public static FacebookDetails GetUserData(string AccessToken)
        {
            FacebookDetails Result = new FacebookDetails();
            Result.AccessToken = AccessToken;
            Result.Graph = ReadGraph(AccessToken);
            //GetLongLivedToken(AccessToken);
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

        public static string GetLongLivedToken(string ShortToken)
        {
            string Result = "";


            string url = "https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token" +
                                            "&client_id=" + ClientIdentifier +
                                            "&client_secret=" + ClientSecret +
                                              "&fb_exchange_token= " + Uri.EscapeDataString(ShortToken);
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, true);
                    Result = streamReader.ReadToEnd();
                }
            }

            return Result;

        }
    }
}