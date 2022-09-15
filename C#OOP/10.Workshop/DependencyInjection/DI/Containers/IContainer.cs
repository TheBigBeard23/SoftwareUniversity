using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.Containers
{
    public interface IContainer
    {
        void ConfigureServices();
        void CreateMapping<TInterfaceType, TImplementationType>();
        Type GetMapping(Type interfaceType);
    }
}
