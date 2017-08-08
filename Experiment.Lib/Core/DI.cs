using Experiment.Lib.Implementation;
using Experiment.Lib.Interface;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Experiment.Lib.Core
{
    public static class DI
    {
        public static void Register(Container container)
        {
            Container = container;

            // Registers all modules
            var factory = new Factory<IModule>();
            factory.Register<ModuleOne>("default");
            factory.Register<ModuleOne>("1");
            factory.Register<ModuleTwo>("2");

            // Registers the factory
            //Container.RegisterSingleton(typeof(IFactory<>), typeof(Factory<>));
            Container.RegisterSingleton<IFactory<IModule>>(factory);
        }

        public static string DependencyVersion { get; set; } = "default";

        internal static Container Container { get; private set; }
    }
}
