
using SOLID.Enums;

namespace SOLID.Appenders
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        int MessagesCount { get; set; }
        void Append(string date, ReportLevel reportLevel, string message);
    }
}
