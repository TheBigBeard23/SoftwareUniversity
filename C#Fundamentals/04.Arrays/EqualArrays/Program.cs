using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumFirstNumbers = 0;
            int sumSecondNumbers = 0;

            for (int i = 0; i < firstNumbers.Length; i++)
            {
                if (firstNumbers[i] != secondNumbers[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }

                sumFirstNumbers += firstNumbers[i];


            }
            for (int j = 0; j < secondNumbers.Length; j++)
            {
                sumSecondNumbers += secondNumbers[j];
            }
            if (sumSecondNumbers == sumFirstNumbers)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumFirstNumbers}");
            }
        }
    }
}
