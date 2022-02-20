using System;

namespace _02.FirstBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int firstBit = 0;

            while (number>0)
            {
                firstBit = number % 2;
                number /= 2;
            }

            Console.WriteLine(firstBit);

            


        }
    }
}
