using System;
using System.Linq;
using TalBrody.DataLayer;
using TalBrody.Entity;
using TalBrody.Common;
using TalBrody.Util;

namespace TalBrody.Logic
{
	public class Users
	{
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
         
	    public static int CreateUser(string email, string password)
	    {
	        int UserId = 0;
            var salt = CommonFunction.CreateSalt();
            var hashed = CommonFunction.Hash(password, salt);
	        UserDal dal = new UserDal();
	        string referralCode = UUIDCreator.Create(8);
            UserId = dal.CreateUser(email, password, hashed, salt, referralCode);

            // TODO Ziv  emil sending for comfermation email address 
	        return UserId;
	    }

        public static int CreateUserWithoutPassword(User user)
        {
            int UserId = 0;
            UserDal dal = new UserDal();
            UserId = dal.CreateUser(user);

            // TODO Ziv  emil sending for comfermation email address 
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
            var hash = CommonFunction.Hash(password, user.PasswordSalt);
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

	    public static string GetUserContext(int UserId)
	    {
	        return UserId.ToString();
	    }

	    public static string GetUserContext(User user)
	    {
	        return GetUserContext(user.Id);
	    }

	    public static int SetUserContext(string Context)
	    {
	        return int.Parse(Context);
	    }

	}
}