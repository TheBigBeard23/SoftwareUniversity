using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToArray();

            Console.WriteLine(Sum(array));
        }
        public static int Sum(int[] array, int index = 0)
        {
            if (index == array.Length)
            {
                return 0;
            }

            int sum = array[index];
            index++;

            sum += Sum(array,index);

            return sum;
        }
    }
}
