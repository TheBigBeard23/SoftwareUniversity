using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());
            int digitSum = 0;

            bool isSpecialNum;
            for (int i = 1; i <= numberCount; i++)
            {
                int currentNumber = i;
                while (i > 0)
                {
                    digitSum += i % 10;
                    i = i / 10;
                }
                isSpecialNum = (digitSum == 5) || (digitSum == 7) || (digitSum == 11);
                Console.WriteLine("{0} -> {1} ", currentNumber, isSpecialNum);
                digitSum = 0;
                i = currentNumber;

            }
        }
    }
}
