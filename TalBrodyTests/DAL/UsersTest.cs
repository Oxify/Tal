using System;
using NUnit.Framework;
using TalBrody;
using TalBrody.Logic;
using System.Text;

namespace TalBrodyTests.DAL
{
    [TestFixture]
    public class UsersTest
    {
        [Test]
        public void FindUserByEmailTest()
        {
            var email = RandomString(10) + "@fake.org";
            var password = "12344321";
            var displayName = "Ron Gross Automatic Test";
            var UserRefId = 1; 
            var users = IOC.GetInstance<Users>();

            // Check user does not exist
            Assert.IsFalse(users.CheckUserPassword(email, password));

            // Create it
            users.AddUser(email, password, displayName, UserRefId);

            // Check it does exist
            Assert.IsTrue(users.CheckUserPassword(email, password));
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
