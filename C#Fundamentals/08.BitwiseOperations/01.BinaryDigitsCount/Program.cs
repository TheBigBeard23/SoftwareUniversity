using System;

namespace _01.BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int binaryDigit = int.Parse(Console.ReadLine());
            int counter = 0;

            while (number>0)
            {
                int currentDigit = number % 2;

                if (currentDigit == binaryDigit)
                {
                    counter++;
                }

                number /= 2;
            }

            Console.WriteLine(counter);
        }
    }
}
