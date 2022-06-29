using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }
        static long Factorial(long n)
        {
            return n != 1 ? n * Factorial(n - 1) : 1;
        }
    }
}
