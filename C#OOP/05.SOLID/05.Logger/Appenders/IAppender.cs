
using SOLID.Enums;

namespace SOLID.Appenders
{
    interface IAppender
    {
        void Append(string date, ReportLevel reportLevel, string message);
    }
}
