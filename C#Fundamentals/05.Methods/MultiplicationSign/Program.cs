using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            PrintSignOnMultiplication(num1, num2, num3);
        }
        static void PrintSignOnMultiplication(double a, double b, double c)
        {
            if (a == 0 ||
                b == 0 ||
                c == 0)
            {
                Console.WriteLine("zero");
            }

            else if (a < 0 && b > 0 && c > 0 ||
                     b < 0 && a > 0 && c > 0 ||
                     c < 0 && a > 0 && b > 0 ||
                     a < 0 && b < 0 && c < 0)
            {
                Console.WriteLine("negative");
            }

            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
