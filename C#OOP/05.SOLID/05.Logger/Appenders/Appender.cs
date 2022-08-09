using SOLID.Enums;
using SOLID.Layouts;

namespace SOLID.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;
        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }
        public int MessagesCount { get; set; }
        public abstract void Append(string date, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }
    }
}
