using AutoMapper;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using FatFoodie.DataAccess;

namespace FatFoodie.IoC.Installers
{
    public class MapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
            Component.For<IMapper>().UsingFactoryMethod(x =>
                { return new MapperConfiguration(cfg => { cfg.AddProfiles(new[] { typeof(IDataAccessRegistrationMarker) }); }).CreateMapper(); }));
        }
    }
}