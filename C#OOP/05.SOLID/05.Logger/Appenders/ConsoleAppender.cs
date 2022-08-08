using SOLID.Enums;
using SOLID.Layouts;
using System;


namespace SOLID.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {

        }
        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            string content = string.Format(layout.Tamplate, date, reportLevel, message);

            Console.WriteLine(content);
        }
    }
}
