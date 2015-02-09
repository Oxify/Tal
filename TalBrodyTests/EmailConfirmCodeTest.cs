using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalBrody.Entity;
using TalBrody.Logic;

namespace TalBrodyTests
{
    [TestClass]
    public class EmailConfirmCodeTest
    {
        [TestMethod]
        public void Sanity()
        {
            User user = new User {Email = "muhamad@ali.com"};
            var code = Users.GenerateUserRegistrationCode(user);

            Users.IsValidRegistrationCode(code, user.Email);
        }
    }
}
