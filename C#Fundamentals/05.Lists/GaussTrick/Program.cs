using System;
using System.Collections.Generic;
using System.Linq;

namespace GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            List<double> newList = new List<double>();

            GaussSum(numbers, newList);

            Console.WriteLine(string.Join(" ",newList));
        }
        static void GaussSum(List<double> numbers, List<double> newList)
        {

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                newList.Add(numbers[i] + numbers[numbers.Count - 1 - i]);
            }
            if (numbers.Count % 2 == 1)
            {
                newList.Add(numbers[numbers.Count / 2 ]);
            }

        }
    }
}
