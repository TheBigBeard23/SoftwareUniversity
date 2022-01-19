using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
      

            for (int i = 0; i < array.Length; i++)
            {
                bool isBigger = true;

                for (int k = i+1; k < array.Length; k++)
                {
                    if (array[i] <= array[k])
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (isBigger)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }
    }
}
