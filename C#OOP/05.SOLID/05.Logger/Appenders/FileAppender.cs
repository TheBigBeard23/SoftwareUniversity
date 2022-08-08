using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFilel;
        public FileAppender(ILayout layout,ILogFile logFile)
            : base(layout)
        {
            this.logFilel = logFile;
        }
        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            string content = string.Format(layout.Tamplate, date, reportLevel, message) +
                Environment.NewLine;

            logFilel.Write(content);
        }
    }
}
