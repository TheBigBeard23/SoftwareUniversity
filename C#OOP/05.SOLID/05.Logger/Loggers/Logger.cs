
using SOLID.Appenders;
using SOLID.Enums;

namespace SOLID.Loggers
{
    class Logger : ILogger
    {
        private readonly IAppender[] appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Error(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.ERROR, message);
        }

        public void Info(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.INFO, message);
        }
        private void AppendToAppenders(string date, ReportLevel reportLevel, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(date, ReportLevel.INFO, message);
            }
        }
    }
}
