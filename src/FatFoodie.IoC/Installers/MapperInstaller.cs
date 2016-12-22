using AutoMapper;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FatFoodie.IoC.Installers
{
    public class MapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn(typeof(Profile))
                    .WithServiceBase()
                    .LifestyleTransient());
        }
    }
}