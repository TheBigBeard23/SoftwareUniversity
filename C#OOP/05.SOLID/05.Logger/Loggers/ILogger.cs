
using SOLID.Appenders;

namespace SOLID.Loggers
{
    interface ILogger
    {
        void Info(string data, string message);
        void Error(string data, string message);
    }
}
