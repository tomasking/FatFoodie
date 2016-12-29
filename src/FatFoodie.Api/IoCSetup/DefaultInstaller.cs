﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FatFoodie.Api.IoCSetup
{
    public class DefaultInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Pick()
                .WithServiceDefaultInterfaces()
                .Configure(c => c.LifestyleTransient()));
        }
    }
}