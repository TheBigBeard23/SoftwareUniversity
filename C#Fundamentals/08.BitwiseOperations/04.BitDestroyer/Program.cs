using System;

namespace _04.BitDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int position = int.Parse(Console.ReadLine());

            int mask = 1 << position;

            mask = ~mask;

            number = number & mask;

            Console.WriteLine(number);
        }
    }
}
