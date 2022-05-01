using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> firstNumbers = new HashSet<int>();
            HashSet<int> secondNumbers = new HashSet<int>();

            for (int i = 0; i < lengths[0]; i++)
            {
                firstNumbers.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < lengths[1]; i++)
            {
                secondNumbers.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var number in firstNumbers)
            {
                if (secondNumbers.Contains(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
