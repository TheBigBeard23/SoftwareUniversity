using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();

            int[] numbers = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbersCount.ContainsKey(numbers[i]))
                {
                    numbersCount[numbers[i]]++;
                }
                else
                {
                    numbersCount[numbers[i]] = 1;
                }
            }

            foreach (var number in numbersCount.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
