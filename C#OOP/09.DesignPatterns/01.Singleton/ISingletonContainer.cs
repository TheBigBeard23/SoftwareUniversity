using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonDemo.Models
{
    public interface ISingletonContainer
    {
        int GetPopulation(string name);
    }
}
