using System.Linq;
using TalBrody.DataLayer;
using TalBrody.Entity;
using TalBrody.Common;

namespace TalBrody.Logic
{
	public class Users
	{
		public static User FindUserByEmail(string email)
		{
			UserDal dal = new UserDal();
			return dal.FindUserByEmail(email);
		}
         
	    public static int CreateUser(string email, string password)
	    {
            var salt = CommonFunction.CreateSalt();
            var hashed = CommonFunction.Hash(password, salt);
	        UserDal dal = new UserDal();
	        return dal.CreateUser(email, password,hashed,salt);
	    }

        public static bool CheckUser(string email, string password)
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
	}
}