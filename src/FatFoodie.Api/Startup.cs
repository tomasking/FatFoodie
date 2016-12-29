using System.Web.Http;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FatFoodie.Api.IoCSetup;
using FatFoodie.IoC;
using Owin;

namespace FatFoodie.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var container = new WindsorContainer().Install(
             new ControllerInstaller(),
             new DefaultInstaller());
            container.Install(FromAssembly.Containing<IIocAssemblyRegistrationMarker>());
            var httpDependencyResolver = new DependencyResolver(container.Kernel);

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = httpDependencyResolver;
            WebApiConfig.Register(config);
            appBuilder.UseWebApi(config);
        }
    }
}