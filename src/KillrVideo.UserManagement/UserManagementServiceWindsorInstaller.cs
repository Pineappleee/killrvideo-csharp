﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace KillrVideo.UserManagement
{
    /// <summary>
    /// Registers all components needed by the user management service with Windsor.
    /// </summary>
    public class UserManagementServiceWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // Most components (override to use Linq implementation of service)
                Classes.FromThisAssembly().Pick().WithServiceFirstInterface().LifestyleTransient()
                       .ConfigureFor<LinqUserManagementService>(c => c.IsDefault())
            );
        }
    }
}
