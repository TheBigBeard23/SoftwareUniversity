using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            for (int i = n1; i <= n2; i++)
            {
                for (int k = 0; k < i.ToString().Length; k++)
                {
                    if (k % 2 == 1)
                    {
                        evenSum += int.Parse(i.ToString()[k].ToString());
                    }
                    else
                    {
                        oddSum += int.Parse(i.ToString()[k].ToString());
                    }


                }

                if (oddSum == evenSum)
                {
                    Console.WriteLine(i);
                }
                oddSum = 0;
                evenSum = 0;
            }
        }
    }
}
