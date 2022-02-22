using System;
using System.Numerics;

namespace _02.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {

            Factorial factorial = new Factorial();
            factorial.number = int.Parse(Console.ReadLine());
            Console.WriteLine(factorial.Calculate());
            
        }

    }
    public class Factorial
    {
        public int number;
        public BigInteger Calculate()
        {
            BigInteger result = number;

            for (int i = 1; i < number; i++)
            {
                result *= i;
            }

            return result;

        }

    }
}
