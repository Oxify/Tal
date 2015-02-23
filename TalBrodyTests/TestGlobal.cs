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
        [SetUp]
        public void Setup()
        {
            IOC.InitContainer(container =>
            {
                var path = Directory.GetCurrentDirectory() + @"..\..\..\..\TalBrody\";
                IOC.Container.Register(
                    Component.For<IResourceResolver>().Instance(new FileSystemResourceResolver(path)));
            });



        }
    }

}
