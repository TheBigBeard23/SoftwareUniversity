using DependencyInjection.DI.Attributes;
using DependencyInjection.DI.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DependencyInjection.DI
{
    public class Injector
    {
        private IContainer container;
        public Injector(IContainer container)
        {
            this.container = container;
        }

        public TClass Inject<TClass>()
        {
            if (!HasConstructorInjection<TClass>())
            {
                throw new ArgumentException("The class has no constructor annoted with the [Inject] attribute ");
            }

            return CreateConstructorInjection<TClass>();
        }
        private TClass CreateConstructorInjection<TClass>()
        {
            ConstructorInfo[] constructors = typeof(TClass).GetConstructors();

            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.GetCustomAttribute(typeof(Inject), true) == null)
                {
                    continue;
                }

                ParameterInfo[] constructorParams = constructor.GetParameters();

                object[] constructorParamObjects = new object[constructorParams.Length];

                int i = 0;

                foreach (ParameterInfo paramInfo in constructorParams)
                {
                    Type interfaceType = paramInfo.ParameterType;
                    Type implementationType = container.GetMapping(interfaceType);

                    object implementationInstance = Activator.CreateInstance
                        (implementationType);

                    constructorParamObjects[i++] = implementationInstance;
                }

                return (TClass)Activator.CreateInstance(typeof
                    (TClass),constructorParamObjects);
            }

            return default;
        }
        private bool HasConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors()
                .Any(c => c.GetCustomAttributes(typeof(Inject), true).Any());
        }
    }
}
