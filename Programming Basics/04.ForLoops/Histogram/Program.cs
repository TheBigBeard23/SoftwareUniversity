using System;
using System.Text;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            double count = int.Parse(Console.ReadLine());
            double to200 = 0;
            double to399 = 0;
            double to599 = 0;
            double to799 = 0;
            double over800 = 0;

            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    to200++;
                }
                else if(num>=200 && num < 400)
                {
                    to399++;
                }
                else if (num >= 400 && num < 600)
                {
                    to599++;
                }
                else if (num >= 600 && num < 800)
                {
                    to799++;
                }
                else
                {
                    over800++;
                }
            }
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"{to200 / count * 100:f2}%");
            sb.AppendLine($"{to399 / count * 100:f2}%");
            sb.AppendLine($"{to599 / count * 100:f2}%");
            sb.AppendLine($"{to799 / count * 100:f2}%");
            sb.AppendLine($"{over800 / count * 100:f2}%");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
