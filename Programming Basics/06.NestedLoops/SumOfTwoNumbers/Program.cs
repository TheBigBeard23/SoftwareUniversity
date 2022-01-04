using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinationsCount = 0;
            bool foundCombination = false;
            for (int i = n1; i <= n2; i++)
            {
                for (int k = n1; k <= n2; k++)
                {
                    combinationsCount++;
                    if (i + k == magicNumber)
                    {
                        foundCombination = true;
                        Console.WriteLine($"Combination N:{combinationsCount} ({i} + {k} = {magicNumber})");
                        break;
                    }
                }
                if (foundCombination)
                {
                    break;
                }
            }

            if (!foundCombination)
            {
                Console.WriteLine($"{combinationsCount} combinations - neither equals {magicNumber}");
            }
        }
    }
}
