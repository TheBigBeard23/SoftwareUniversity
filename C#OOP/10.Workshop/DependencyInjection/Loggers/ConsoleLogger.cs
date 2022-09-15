using DependencyInjection.Contracts;
using System;

namespace DependencyInjection.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
