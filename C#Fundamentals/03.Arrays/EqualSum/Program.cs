using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            bool isEqual = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftsum = 0;
                int rightSum = 0;

                for (int k = i + 1; k < numbers.Length; k++)
                {
                    rightSum += numbers[k];
                }
                for (int j = i - 1; j >= 0; j--)
                {
                    leftsum += numbers[j];
                }

                if (leftsum == rightSum)
                {
                    isEqual = true;
                    Console.WriteLine(i);
                    return;
                }

            }
            if(!isEqual)
            {
                Console.WriteLine("no");
            }

        }
    }
}
