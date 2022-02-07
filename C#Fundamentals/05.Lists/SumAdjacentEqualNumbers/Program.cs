using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            SumEqualNumbers(numbers);

            Console.WriteLine(String.Join(" ", numbers));
        }

        static void SumEqualNumbers(List<double> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i--;
                }
            }

            //    for (int i = 0; i < numbers.Count-1; i++)
            //    {
            //        int nextIndex = i + 1;

            //        if (numbers[i] == numbers[nextIndex])
            //        {
            //            numbers[i] += numbers[nextIndex];
            //            numbers.RemoveAt(nextIndex);
            //            i = -1;
            //        }
            //    }
            //
        }
    }
}
