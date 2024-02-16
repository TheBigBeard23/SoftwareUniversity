using Logger.Appenders;
using Logger.Enums;
using Logger.Layouts;

namespace Logger.Core.Factories
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string typeName, ILayout layout, ReportLevel reportLevel);
    }
}
