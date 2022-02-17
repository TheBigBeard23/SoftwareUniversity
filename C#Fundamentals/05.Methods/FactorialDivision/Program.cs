using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double firstFactorial = GetFactorial(firstNumber);
            double secondFactorial = GetFactorial(secondNumber);
            double result = firstFactorial / secondFactorial;

            Console.WriteLine($"{result:f2}");

        }
        static double GetFactorial(double number)
        {
            double result = 1;

            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
