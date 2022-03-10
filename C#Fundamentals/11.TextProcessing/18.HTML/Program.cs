using System;
using System.Text;

namespace _18.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string title = Console.ReadLine();
            string content = Console.ReadLine();

            sb.AppendLine($"<h1>");
            sb.AppendLine($"    {title}");
            sb.AppendLine($"</h1>");
            sb.AppendLine($"<article>");
            sb.AppendLine($"    {content}");
            sb.AppendLine($"</article>");

            string comment = Console.ReadLine();

            while (comment != "end of comments")
            {
                sb.AppendLine($"<div>");
                sb.AppendLine($"    {comment}");
                sb.AppendLine($"</div>");

                comment = Console.ReadLine();
            }

            Console.WriteLine(sb);
        }
    }
}
