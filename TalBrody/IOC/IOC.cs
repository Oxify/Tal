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

        public static void InitContainer()
        {
            Container = new WindsorContainer();
            Container.Install(
            //new ControllersInstaller(),
                new RepositoriesInstaller()
           // and all your other installers
           );
        }

        public static object ResolveType(this IWindsorContainer container, Type type)
        {
            if (type.IsClass && !container.Kernel.HasComponent(type))
            {
                container.Kernel.AddComponent(type.FullName, type, LifestyleType.Transient);
            }
            return container.Resolve(type);
        }

        public static T ResolveType<T>(this IWindsorContainer container)
        {
            // http://stackoverflow.com/questions/447193/resolving-classes-without-registering-them-using-castle-windsor
            return (T)ResolveType(container, typeof(T)); 
        }
    }
}