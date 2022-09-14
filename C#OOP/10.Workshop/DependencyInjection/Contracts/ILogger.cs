using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Contracts
{
    public interface ILogger
    {
        void Log(string message);
    }
}
