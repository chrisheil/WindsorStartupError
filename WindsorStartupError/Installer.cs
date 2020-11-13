using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Extensions.DependencyInjection.Extensions;

namespace WindsorStartupError
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ITestService>()
                    .ImplementedBy<TestService>()
                    .LifeStyle.ScopedToNetServiceScope()
            );
        }
    }
}
