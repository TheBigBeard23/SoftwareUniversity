using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < numbers; i++)
            {
                firstSum += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < numbers; i++)
            {
                secondSum += int.Parse(Console.ReadLine());
            }

            if (firstSum == secondSum)
            {
                Console.WriteLine($"Yes, sum = {firstSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs( secondSum-firstSum)}");
            }
        }
    }
}
