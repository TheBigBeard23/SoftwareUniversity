using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Appenders;
using SOLID.Enums;
using SOLID.Layouts;

namespace SOLID.Core.Factories
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel);
    }
}
