using System;
using System.Linq;

namespace _11.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();

            int divider = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseArrayDelagate = ReverseArray;

            Predicate<int> checkNumber = x => x % divider == 0;

            foreach (var num in reverseArrayDelagate(numbers))
            {
                if (checkNumber(num))
                {
                    Console.Write($"{num} ");
                }
            }

        }
        static int[] ReverseArray(int[] array)
        {
            int[] newArr = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArr[i] = array[array.Length - 1 - i];
            }

            return newArr;
        }
    }
}
