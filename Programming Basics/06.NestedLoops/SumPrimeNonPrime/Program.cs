using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeNumbersSum = 0, nonPrimeNumbersSum = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {

                    break;

                }

                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                int dividersCount = 0;

                for (int i = 1; i <=number; i++)
                {
                    if (number % i == 0)
                    {
                        dividersCount++;
                    }
                }

                if (dividersCount > 2)
                {
                    nonPrimeNumbersSum += number;
                }
                else
                {
                    primeNumbersSum += number;
                }
                

            }
            Console.WriteLine($"Sum of all prime numbers is: {primeNumbersSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumbersSum}");
        }
    }
}
