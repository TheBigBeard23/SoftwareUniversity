using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbersCount = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numbersCount.ContainsKey(numbers[i]))
                {
                    numbersCount[numbers[i]] = 0;
                }

                numbersCount[numbers[i]]++;
            }

            foreach (var number in numbersCount)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
