using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(", ")
                            .Select((x) =>
                            {
                                return int.Parse(x);
                            })
                            .Where(x => CheckEven(x))
                            .OrderBy(x => x)
                            .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
        static bool CheckEven(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
