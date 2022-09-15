using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class Inject : Attribute
    {
    }
}
