
using SOLID.Appenders;
using SOLID.Enums;

namespace SOLID.Loggers
{
    class Logger : ILogger
    {
        private IAppender appender;
        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public void Error(string date, string message)
        {
            appender.Append(date, ReportLevel.ERROR, message);
        }

        public void Info(string date, string message)
        {
            appender.Append(date, ReportLevel.INFO, message);
        }
    }
}
