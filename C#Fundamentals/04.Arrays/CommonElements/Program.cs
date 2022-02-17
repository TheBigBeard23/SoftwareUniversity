using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split()
                .ToArray();

            string[] secondArray = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < secondArray.Length; i++)
            {
                if (firstArray.Contains(secondArray[i]))
                {
                    Console.Write($"{secondArray[i]} ");
                }
            }

        }
    }
}
