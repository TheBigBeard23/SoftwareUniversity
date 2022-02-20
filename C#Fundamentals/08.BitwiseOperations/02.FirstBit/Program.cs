using System;

namespace _02.FirstBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int shiftedNumber = number >> 1;

            int result = shiftedNumber & 1;

            Console.WriteLine(result);

            


        }
    }
}
