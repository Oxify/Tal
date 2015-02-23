using System.IO;
using Castle.MicroKernel.Registration;
using NUnit.Framework;
using TalBrody;
using TalBrody.Util;

namespace TalBrodyTests
{
    [SetUpFixture]
    public class TestGlobal
    {
        [SetUp] // This is run once globally
        public void Setup()
        {
            IOC.InitContainer(container =>
            {
                IOC.Container.Register(
                    Component.For<IResourceResolver>().Instance(new MockResourceResolver()));
            });
        }
    }

    public class MockResourceResolver : IResourceResolver
    {
        public string Resolve(string path)
        {
            return "A";
        }
    }
}
