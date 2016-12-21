using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FatFoodie.Application.Configuration;
using FatFoodie.Application.Recipe;
using FatFoodie.DataAccess;
using ConfigurationSettings = FatFoodie.Infrastructure.Configuration.ConfigurationSettings;
using IConfigurationSettings = FatFoodie.Infrastructure.Configuration.IConfigurationSettings;

namespace FatFoodie.Infrastructure.Installers
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
