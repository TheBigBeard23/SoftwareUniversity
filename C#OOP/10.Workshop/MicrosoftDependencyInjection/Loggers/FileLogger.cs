using MicrosoftDependencyInjection.Contracts;
using System.IO;

namespace MicrosoftDependencyInjection.Loggers
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../logs.txt", true))
            {
                writer.WriteLine(message); 
            }
        }
    }
}
