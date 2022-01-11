using System;
using System.Linq;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int[] numbers = { a, b, c };
            int maxNumber = numbers.Max();
            int minNumber = numbers.Min();
            int avgNumber = (a + b + c) - (maxNumber + minNumber);

            Console.WriteLine(maxNumber);
            Console.WriteLine(avgNumber);
            Console.WriteLine(minNumber);
        }
    }
}
