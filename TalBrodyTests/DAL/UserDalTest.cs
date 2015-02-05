using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fblogin.DataLayer;

namespace TalBrodyTests.DAL
{
    [TestClass]
    public class UserDalTest
    {
        [TestMethod]
        public void FindUserByEmailTest()
        {
            var name = "Muhamad Ali";
            var password = "12344321";

            var users = new UserDal();
            
            // Check user does not exist
            Assert.IsFalse(users.CheckUser(name, password));

            // Create it
            users.CreateUser(name, password);

            // Check it does exist
            Assert.IsTrue(users.CheckUser(name, password));
        }
    }
}
