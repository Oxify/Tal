using System;
using Castle.Core;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace TalBrody
{
    public static class IOC
    {
        public static WindsorContainer Container { get; private set; }

        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static void InitContainer(Action<WindsorContainer> action)
        {
            Container = new WindsorContainer();
            action(Container);
            Container.Install(
                new RepositoriesInstaller()
           );
        }
    }
}