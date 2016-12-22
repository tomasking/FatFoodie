using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using FatFoodie.Application.Recipe;
using FatFoodie.Configuration;
using FatFoodie.DataAccess;

namespace FatFoodie.IoC.Installers
{
    public class ApplicationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IRecipeService>().ImplementedBy<RecipeService>(),
                Component.For<IConfigurationSettings>().ImplementedBy<ConfigurationSettings>(),
                Component.For<IRecipeRepository>().ImplementedBy<SqlRecipeRepository>());
        }
    }
}
