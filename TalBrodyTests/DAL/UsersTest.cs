using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalBrody.DataLayer;
using TalBrody.Logic;

namespace TalBrodyTests.DAL
{
    [TestClass]
    public class UsersTest
    {
        [TestMethod]
        public void FindUserByEmailTest()
        {
            var name = "Muhamad Ali";
            var password = "12344321";

            var users = new UserDal();
            
            // Check user does not exist
            Assert.IsFalse(Users.CheckUserPassword(name, password));

            // Create it
            Users.CreateUser(name, password);

            // Check it does exist
            Assert.IsTrue(Users.CheckUserPassword(name, password));
        }
    }
}
