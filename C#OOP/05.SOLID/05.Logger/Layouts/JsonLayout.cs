using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Tamplate
        {
            get
            {
                var sb = new StringBuilder();

                sb.AppendLine(@"""log"": {{");
                sb.AppendLine(@"  ""date"": ""{0}"",");
                sb.AppendLine(@"  ""level"": ""{1}"",");
                sb.AppendLine(@"  ""message"": ""{2}""");
                sb.AppendLine("}}");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
