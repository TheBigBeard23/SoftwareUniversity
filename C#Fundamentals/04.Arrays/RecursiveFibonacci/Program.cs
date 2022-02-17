using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(number));
        }

        private static int GetFibonacci(int number)
        {

            if (number <= 1)
            {
                return number;
            }
            else
            {
                return GetFibonacci(number - 1) + GetFibonacci(number - 2);
            }
        }
    }
}
