using System;

namespace _03.PthBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int position = int.Parse(Console.ReadLine());

            int shiftedNumber = number >> position;

            Console.WriteLine(shiftedNumber & 1);




        }
    }
}
