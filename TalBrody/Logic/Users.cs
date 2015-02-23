using System;
using System.Linq;
using System.Reflection;
using log4net;
using TalBrody.DataLayer;
using TalBrody.Entity;
using TalBrody.Common;
using TalBrody.Util;

namespace TalBrody.Logic
{
	public class Users
	{
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public static User FindUserByEmail(string email)
		{
			UserDal dal = new UserDal();
            return dal.FindUserByEmail(email);
		}

        public static User FindUserByFacebookd(int facebookd)
        {
            UserDal dal = new UserDal();
            return dal.FindUserByFacebookd(facebookd);
        }

        public static User FindUserByid(int id)
        {
            UserDal dal = new UserDal();
            return dal.FindUserByid(id);
        }

        public static User FindUserByTwitterid(int Twitterid)
        {
            UserDal dal = new UserDal();
            return dal.FindUserByTwitterid(Twitterid);
        }

	    public static User AddUser(string emailStr, string password, string displayNameA)
        {
            log.Info(String.Format("Creating new user (email, name) = ({0}, {1})", emailStr, displayNameA));

            var dal = new UserDal();

            // Create User
	        var salt = SessionUtil.CreateSalt();
            var hashed = SessionUtil.Hash(password, salt);
            var referralCode = UUIDCreator.Create(8);
            dal.CreateUser(emailStr, password, hashed, salt, referralCode);

            // Update with display name (TODO - no need for a separate update)
	        var user = dal.FindUserByEmail(emailStr);
            user.DisplayName = displayNameA;
            UpdateUser(user);

            var code = GenerateUserRegistrationCode(user);
            new Email().SendRegistrationEmail(user, code);

            return user;
        }

        public static int CreateUserWithoutPassword(User user)
        {
            int UserId = 0;
            UserDal dal = new UserDal();
            UserId = dal.CreateUser(user);
            user.Id = UserId;
            //dal.UpdateUser(user);
           
            return UserId;
        }
        
        public static void UpdateUser(User user)
	    {
	        UserDal dal = new UserDal();
            dal.UpdateUser(user);
	    }

        public static bool CheckUserPassword(string email, string password)
        {
            var user = FindUserByEmail(email);
            if (user == null)
            {
                //log.Debug("Didn't find user with email = " + email);
                return false;
            }
            var hash = SessionUtil.Hash(password, user.PasswordSalt);
            return hash.SequenceEqual(user.PasswordHash);
        }

        /// <summary>
        /// Gets a unique code for this user, used to verify his email account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
	    public static string GenerateUserRegistrationCode(User user)
        {
            var code = UUIDCreator.Create(8);
            var dal = new EmailConfirmDal();

            dal.StoreConfirmCode(code, user.Email);
            return code;
        }

	    public static bool IsValidRegistrationCode(string code, string email)
	    {
	        var dal = new EmailConfirmDal();
	        var storedCode = dal.FindConfirmCode(code, email);
            return storedCode != null;
	    }

	    public static string GetUserContext(int userId)
	    {
	        return userId.ToString();
	    }

	    public static string GetUserContext(User user)
	    {
	        return GetUserContext(user.Id);
	    }

	    public static int SetUserContext(string context)
	    {
	        return Int32.Parse(context);
	    }
	}
}