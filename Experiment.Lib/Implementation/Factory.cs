using Experiment.Lib.Core;
using Experiment.Lib.Interface;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Experiment.Lib.Implementation
{
    public sealed class Factory<T> : IFactory<T> where T : class
    {
        private readonly Dictionary<string, InstanceProducer<T>> _producers;

        public Factory()
        {
            if (!typeof(T).GetTypeInfo().IsInterface)
                throw new Exception("The requested object type must be an interface");

            _producers = new Dictionary<string, InstanceProducer<T>>(StringComparer.OrdinalIgnoreCase);
        }

        public T GetInstance(string version = "default") => _producers[version].GetInstance();

        public void Register<TImplementation>(string version, Lifestyle lifestyle = null)
        where TImplementation : class, T
        {
            if (typeof(TImplementation).GetTypeInfo().IsInterface)
                throw new Exception("The implementation object type cannot be an interface");

            var container = DI.Container;

            var producer = (lifestyle ?? container.Options.DefaultLifestyle)
                .CreateProducer<T, TImplementation>(container);

            _producers.Add(version, producer);
        }
    }
}
