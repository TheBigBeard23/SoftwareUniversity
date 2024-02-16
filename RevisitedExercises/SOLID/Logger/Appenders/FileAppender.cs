using Logger.Enums;
using Logger.Layouts;
using Logger.Loggers;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            string content = string.Format(layout.Tamplate, date, reportLevel, message) +
                Environment.NewLine;

            logFile.Write(content);
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }
    }
}
