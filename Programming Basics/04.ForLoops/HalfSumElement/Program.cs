using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int maxNum = 0;
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (maxNum < num)
                {
                    sum -= num;
                    maxNum = num;
                }

            }

            if (maxNum == sum)
            {
                Console.WriteLine($"Yes{Environment.NewLine}Sum = {sum}");
            }
            else
            {
                Console.WriteLine($"No{Environment.NewLine}Diff = {Math.Abs(maxNum-sum)}");
            }
        }
    }
}
