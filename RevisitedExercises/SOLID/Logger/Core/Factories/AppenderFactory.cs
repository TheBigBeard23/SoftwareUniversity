using Logger.Appenders;
using Logger.Enums;
using Logger.Layouts;
using Logger.Loggers;

namespace Logger.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string typeName, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender = null;

            switch (typeName)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = reportLevel
                    };
                    break;

                case nameof(FileAppender):

                    appender = new FileAppender(layout, new LogFile())
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                default:
                    throw new ArgumentException($"{typeName} is invalid Appender type.");

            }
            return appender;

        }
    }
}
