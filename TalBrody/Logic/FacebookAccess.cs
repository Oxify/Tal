﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using DotNetOpenAuth.ApplicationBlock.Facebook;
using TalBrody.DataLayer;
using TalBrody.Entity;
using TalBrody.Util;
using log4net;

namespace TalBrody.Logic
{
    public class FacebookAccess
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string ClientIdentifier;
        private readonly string ClientSecret;
        private readonly Users _users;
        private readonly Email _email;

        public FacebookAccess()
        {
            ClientIdentifier = ConfigurationManager.AppSettings["facebookAppID"];
            ClientSecret = ConfigurationManager.AppSettings["facebookAppSecret"];

            _users = IOC.GetInstance<Users>(); // TODO move to ctor params
            _email = IOC.GetInstance<Email>();
        }


        public class FacebookDetails
        {
            public string AccessToken { get; set; }
            public FacebookGraph Graph { get; set; }
            public List<FacebookFriendsData> Friends { get; set; }

        }

        public User LoginUser(string AccessToken)
        {

            var data = GetUserData(AccessToken);
            User user = null;
            if (data.Graph != null)
            {
                Users users = new Users();
                user = users.FinduserByFaceBookId(data.Graph.Id);
            }
            
            if (user == null)
            {
                return null;
            }

            // user logged in, let's update the DB
            PopulateUser(data, ref user);
            UserDal dal = new UserDal();
            dal.UpdateUser(user);
            
            return user;
        }

        public User RegisterUser(string AccessToken, string email)
        {

            var data = GetUserData(AccessToken);
            User user = null;
            if (data.Graph.EMail == null)
            {
                if ((email != null) && (email.IndexOf('@') != -1))
                {
                    data.Graph.EMail = email;
                }
            }

            if (data.Graph.EMail != null)
            {
                Users users = new Users();
                user = users.FindUserByEmail(data.Graph.EMail);
            }
            else if (data.Graph != null)
            {
                Users users = new Users();
                user = users.FinduserByFaceBookId(data.Graph.Id);
            }

            if (user != null)
            {
                if (user.Email == null)
                {
                    return user;
                }
            }

            if (user == null)
            {

                // no id, new user!
                user = new User();
                PopulateUser(data, ref user);
                if (user.Email == null)
                {
                    return user;
                }

                user.Id = _users.CreateUserWithoutPassword(user);

                if (user.Email != null)
                {

                    var code = _users.GenerateUserRegistrationCode(user);
                    _email.SendRegistrationEmail(user, code);
                }
            }
            else
            {

                // user already registered somehow, let's update the DB
                PopulateUser(data, ref user);
                UserDal dal = new UserDal();
                dal.UpdateUser(user);
            }

            return user;
        }


        private static void PopulateUser(FacebookDetails details, ref Entity.User user)
        {
            user.FacebookAccessToken = details.AccessToken;
            user.FacebookId = details.Graph.Id;
            if (details.Graph.EMail != null)
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

        public string GetLongLivedToken(string ShortToken)
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