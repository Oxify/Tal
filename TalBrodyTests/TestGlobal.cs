using NUnit.Framework;
using TalBrody;

namespace TalBrodyTests
{
    [SetUpFixture]
    public class TestGlobal
    {
        [SetUp]
        public void Setup()
        {
            IOC.InitContainer();
        }
    }

}
