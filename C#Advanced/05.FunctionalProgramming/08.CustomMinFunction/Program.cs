using System;
using System.Linq;

namespace _08.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();

            Func<int[], int> getMinValueDelegate = GetMinValue;

            Console.WriteLine(getMinValueDelegate(numbers)); 
        }
        static int GetMinValue(int[] numbers)
        {
            int minValue = int.MaxValue;

            foreach (var number in numbers)
            {
                if (minValue > number)
                {
                    minValue = number;
                }
            }

            return minValue;
        }
    }
}
