using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int count = int.Parse(Console.ReadLine());

            int[] firstArray = new int[4];
            int[] secondArray = new int[4];
            int firstCounter = 0;
            int secondCounter = 0;

            for (int i = 1; i <= count; i++)
            {
                int[] array = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 1)
                {
                    firstArray[firstCounter] = array[0];
                    secondArray[secondCounter] = array[1];
                    firstCounter++;
                    secondCounter++;
                }
                else
                {
                    firstArray[firstCounter] = array[1];
                    secondArray[secondCounter] = array[0];
                    firstCounter++;
                    secondCounter++;
                }

            }

            Console.WriteLine(String.Join(" ",firstArray));
            Console.WriteLine(String.Join(" ", secondArray));

        }
    }
}
