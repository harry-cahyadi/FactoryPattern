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
            var moduleFactory = new Factory<IModule>();
            moduleFactory.Register<ModuleOne>("0");
            moduleFactory.Register<ModuleOne>("1");
            moduleFactory.Register<ModuleTwo>("2");

            // Registers all other modules
            var otherModuleFactory = new Factory<IOtherModule>();
            otherModuleFactory.Register<OtherModuleOne>("0");
            otherModuleFactory.Register<OtherModuleOne>("1");
            otherModuleFactory.Register<OtherModuleTwo>("2");

            // Registers all factories
            Container.RegisterSingleton<IFactory<IModule>>(moduleFactory);
            Container.RegisterSingleton<IFactory<IOtherModule>>(otherModuleFactory);
        }

        public static IDictionary<string, string> DependencyVersions { get; set; } =
            new Dictionary<string, string>() {
                { GetDependencyNamespace<IModule>(), "0"},
                { GetDependencyNamespace<IOtherModule>(), "1"}
            };

        public static string GetDependencyVersion<T>()
            where T : class
        {
            return DependencyVersions != null ? DependencyVersions[GetDependencyNamespace<T>()] : "0";
        }

        internal static Container Container { get; private set; }

        internal static string GetDependencyNamespace<T>()
            where T : class
        {
            var namespaceIncludingClassName = typeof(T).ToString();
            var assemblyName = typeof(T).Assembly.GetName().Name;

            return $"{namespaceIncludingClassName},{assemblyName}";
        }
    }
}
