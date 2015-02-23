using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalBrody.Common;
using TalBrody.DataLayer;
using TalBrody.Logic;
using System.Text;
using TalBrody.Util;

namespace TalBrodyTests.DAL
{
    [TestClass]
    public class UsersTest
    {
        [Ignore("TODO Ron, fixing it")]
        [TestMethod]
        public void FindUserByEmailTest()
        {
            var email = RandomString(10) + "@mail.com";
            var password = "12344321";
            var displayName = "John Doe";

            var users = new UserDal();
            
            // Check user does not exist
            Assert.IsFalse(Users.CheckUserPassword(email, password));

            // Create it
            Users.AddUser(email, password, displayName);

            // Check it does exist
            Assert.IsTrue(Users.CheckUserPassword(email, password));
        }

        #region Helpers

        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        #endregion
    }
}
