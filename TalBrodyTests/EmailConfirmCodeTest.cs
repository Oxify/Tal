using NUnit.Framework;
using TalBrody;
using TalBrody.Entity;
using TalBrody.Logic;

namespace TalBrodyTests
{
    [TestFixture]
    public class EmailConfirmCodeTest
    {
        [Test]
        public void Sanity()
        {
            var users = IOC.GetInstance<Users>();

            User user = new User {Email = "muhamad@ali.com"};
            var code = users.GenerateUserRegistrationCode(user);

            users.IsValidRegistrationCode(code, user.Email);
        }
    }
}
