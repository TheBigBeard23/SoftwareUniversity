using System;

namespace PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];

            for (int i = n-1; i >= 0; i--)
            {
                nums[i] = int.Parse(Console.ReadLine());

            }

            Console.WriteLine(String.Join(" ",nums));
        }
    }
}
