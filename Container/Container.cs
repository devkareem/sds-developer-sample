using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _bindings;

        public Container()
        {
            _bindings = new Dictionary<Type, Type>();
        }
        public void Bind(Type interfaceType, Type implementationType)
        {
            ValidateInterfaceAndImplementationTypes(interfaceType, implementationType);

            _bindings[interfaceType] = implementationType;
        }

        private static void ValidateInterfaceAndImplementationTypes(Type interfaceType, Type implementationType)
        {
            if (interfaceType is null)
                throw new ArgumentNullException(nameof(interfaceType));

            if (implementationType is null)
                throw new ArgumentNullException(nameof(implementationType));
        }

        public T Get<T>() where T : class
        {
            var keyType = typeof(T);
            if (!_bindings.ContainsKey(keyType))
                throw new KeyNotFoundException($"the type {keyType.FullName} doesn't exists.");
            
            return (T)Activator.CreateInstance(_bindings[keyType]);
        }
    }
}