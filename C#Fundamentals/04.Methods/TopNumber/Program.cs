using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                PrintTopNumber(i);
            }
        }
        static void PrintTopNumber(int n)
        {
            if (n > 16)
            {
                string number = n.ToString();
                int sum = 0;
                bool isContainsOddDigit = false;

                for (int i = 0; i < number.Length; i++)
                {
                    int currentDigit = int.Parse(number[i].ToString());

                    if (currentDigit % 2 == 1)
                    {
                        isContainsOddDigit = true;
                    }
                    sum += currentDigit;
                }

                if (sum % 8 == 0 &&
                    isContainsOddDigit)
                {
                    Console.WriteLine(n);
                }
            }
        }
    }
}
