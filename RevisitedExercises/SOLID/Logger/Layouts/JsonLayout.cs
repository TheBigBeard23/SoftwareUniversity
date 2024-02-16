using System.Text;

namespace Logger.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Tamplate
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(@"""log"": {{");
                sb.AppendLine(@"   ""date"": ""{0}"",");
                sb.AppendLine(@"   ""level"": ""{1}"",");
                sb.AppendLine(@"   ""message"": ""{2}"",");
                sb.AppendLine("}}");

                return sb.ToString().Trim();
            }
        }
    }
}
