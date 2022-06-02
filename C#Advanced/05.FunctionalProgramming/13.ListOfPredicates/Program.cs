using System;
using System.Linq;

namespace _13.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            Func<int, int[], bool> CheckNumbersDelegate = CheckNumber;

            for (int i = 1; i <= end; i++)
            {
                if (CheckNumbersDelegate(i, dividers))
                {
                    Console.Write($"{i} ");
                }
            }

        }
        static bool CheckNumber(int number,int[] dividers)
        {
            for (int i = 0; i < dividers.Length; i++)
            {
                int currentNum = dividers[i];

                if (number % currentNum > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
