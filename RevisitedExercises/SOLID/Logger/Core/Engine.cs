using Logger.Appenders;
using Logger.Core.Factories;
using Logger.Core.IO;
using Logger.Enums;
using Logger.Layouts;
using Logger.Loggers;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;
        private readonly IReader reader;
        private ILogger logger;

        public Engine(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory, IReader reader)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
            this.reader = reader;
        }

        public void Run()
        {
            int count = int.Parse(reader.ReadLine());
            IAppender[] appenders = ReadAppenders(count);

            logger = new Loggger(appenders);

            string input = string.Empty;

            while ((input = reader.ReadLine()) != "END")
            {
                string[] logParts = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(logParts[0]);
                string date = logParts[1];
                string message = logParts[2];

                ProcessCommand(reportLevel, date, message);
            }

            Console.WriteLine(logger);
        }
        private void ProcessCommand(ReportLevel reportLevel, string date, string message)
        {
            switch (reportLevel)
            {
                case ReportLevel.INFO:
                    logger.Info(date, message);
                    break;
                case ReportLevel.WARNING:
                    logger.Warning(date, message);
                    break;
                case ReportLevel.ERROR:
                    logger.Error(date, message);
                    break;
                case ReportLevel.CRITICAL:
                    logger.Critical(date, message);
                    break;
                case ReportLevel.FATAL:
                    logger.Fatal(date, message);
                    break;
            }
        }

        private IAppender[] ReadAppenders(int count)
        {
            IAppender[] appenders = new IAppender[count];

            for (int i = 0; i < count; i++)
            {
                string[] appenderParts = reader.ReadLine().Split();

                string appenderType = appenderParts[0];
                string layoutType = appenderParts[1];

                ReportLevel reportLevel = appenderParts.Length == 3
                   ? Enum.Parse<ReportLevel>(appenderParts[2])
                   : ReportLevel.INFO;

                ILayout layout = layoutFactory
                    .CreateLayout(layoutType);
                IAppender appender = appenderFactory
                    .CreateAppender(appenderType, layout, reportLevel);

                appenders[i] = appender;
            }

            return appenders;
        }
    }
}
