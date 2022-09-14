using MicrosoftDependencyInjection.Contracts;
using System;

namespace MicrosoftDependencyInjection.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
