using SOLID.Appenders;
using SOLID.Layouts;
using SOLID.Loggers;
using System;

namespace SOLID
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            ILayout xmlLayout = new xmlLayout();

            var file = new LogFile();

            IAppender fileAppender = new FileAppender(simpleLayout, file);
            IAppender consoleAppender = new ConsoleAppender(xmlLayout);

            ILogger logger = new Logger(consoleAppender, fileAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
