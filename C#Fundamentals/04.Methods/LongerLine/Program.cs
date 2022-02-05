using System;

namespace LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintLongestLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }
        static void PrintLongestLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double firstLine = Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
            double secondLine = Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2);

            if (firstLine >= secondLine)
            {
                ClosestToZero(x1, y1, x2, y2);
            }
            else
            {
                ClosestToZero(x3, y3, x4, y4);
            }

        }
        static void ClosestToZero(double x1, double y1, double x2, double y2)
        {

            if (x1 * x1 + y1 * y1 <= x2 * x2 + y2 * y2)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}
