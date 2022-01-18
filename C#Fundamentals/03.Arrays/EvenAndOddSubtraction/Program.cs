using System;
using System.Linq;

namespace EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumEvenNumbers = 0;
            int sumOddNumbers = 0;
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumEvenNumbers += numbers[i];
                }
                else
                {
                    sumOddNumbers += numbers[i];
                }
                result = sumEvenNumbers - sumOddNumbers;
            }

            Console.WriteLine(result);
        }
    }
}
