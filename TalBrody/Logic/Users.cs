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
        public Users(UserDal userDal, EmailConfirmDal emailConfirmDal)
        {
            _userDal = userDal;
            _emailConfirmDal = emailConfirmDal;
        }

        public Users()
        {
            _userDal = new UserDal();
            _emailConfirmDal = new EmailConfirmDal();
        }

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly UserDal _userDal;
        private readonly EmailConfirmDal _emailConfirmDal;

        public void UpdateUser(User user)
        {
           _userDal.UpdateUser(user);
        }

        public User AddUser(string emailStr, string password, string displayNameA, int RefUserId)
        {
            log.Info(String.Format("Creating new user (email, name) = ({0}, {1})", emailStr, displayNameA));

            // Create User
            var salt = SessionUtil.CreateSalt();
            var hashed = SessionUtil.Hash(password, salt);
            var referralCode = UUIDCreator.Create(8);
            _userDal.CreateUser(emailStr, password, hashed, salt, referralCode);

            // Update with display name (TODO - no need for a separate update)
            var user = _userDal.FindUserByEmail(emailStr);
            user.DisplayName = displayNameA;
            UserDal dal1 = new UserDal();
            dal1.UpdateUser(user);

            // Send registration email
            var code = GenerateUserRegistrationCode(user);
            IOC.GetInstance<Email>().SendRegistrationEmail(user, code);

            // add folower to th project 
            if (RefUserId > 0)
                Followers.Insert_Follwer(1, user.Id, RefUserId);

            return user;
        }

        public User FindUserByEmail(string email)
        {
            return _userDal.FindUserByEmail(email);
        }

        public User FinduserByFaceBookId(long FaceBookId)
        {
           return  _userDal.FindUserByFacebookId((int)FaceBookId);
        }

        public User FinduserByFaceBookId(int FaceBookId)
        {
            return _userDal.FindUserByFacebookId(FaceBookId);
        }

        public User FindUserByUserId(int UserId)
        {
            return _userDal.FindUserByid(UserId);

        }

        public int CreateUserWithoutPassword(User user)
        {
            int UserId = _userDal.CreateUser(user);
            user.Id = UserId;
            //dal.UpdateUser(user);


            return UserId;
        }

        public bool CheckUserPassword(string email, string password)
        {
            var user = _userDal.FindUserByEmail(email);
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
        public string GenerateUserRegistrationCode(User user)
        {
            var code = UUIDCreator.Create(8);
            _emailConfirmDal.StoreConfirmCode(code, user.Email);
            return code;
        }

        public bool IsValidRegistrationCode(string code, string email)
        {
            var storedCode = _emailConfirmDal.FindConfirmCode(code, email);
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