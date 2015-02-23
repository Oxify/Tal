using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TalBrody.Logic;

namespace TalBrody
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(Component.IsInNamespace("TalBrody", true))
                .WithService.DefaultInterfaces()
                .LifestyleTransient());
        }
    }
}