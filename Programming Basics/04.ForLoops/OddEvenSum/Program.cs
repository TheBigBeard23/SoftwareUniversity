using System;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 1; i <= count; i++)
            {
                if (i % 2 == 1)
                {
                    oddSum += int.Parse(Console.ReadLine());
                }
                else
                {
                    evenSum += int.Parse(Console.ReadLine());
                }
            }

            if (oddSum == evenSum)
            {
                Console.WriteLine($"Yes{Environment.NewLine}Sum = {oddSum}");
            }
            else
            {
                Console.WriteLine($"No{Environment.NewLine}Diff = {Math.Abs(oddSum-evenSum)}");
            }
        }
    }
}
