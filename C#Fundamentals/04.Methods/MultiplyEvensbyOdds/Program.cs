using System;

namespace MultiplyEvensbyOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int sumOfEvenDigits = GetSumOfEvenDigits(number);
            int sumOfOddDigits = GetSumOfOddDigits(number);

            Console.WriteLine(sumOfEvenDigits + sumOfOddDigits); ;
        }
        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;
            string numberAsString = number.ToString();

            for (int i = 0; i < numberAsString.Length; i++)
            {
                int currentNumber = int.Parse(numberAsString[i].ToString());

                if (currentNumber % 2 == 0)
                {
                    sum += currentNumber;
                }
            }

            return sum;
        }
        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            string numberAsString = number.ToString();

            for (int i = 0; i < numberAsString.Length; i++)
            {
                int currentNumber = int.Parse(numberAsString[i].ToString());

                if (currentNumber % 2 == 1)
                {
                    sum += currentNumber;
                }
            }

            return sum;
        }
    }
}
