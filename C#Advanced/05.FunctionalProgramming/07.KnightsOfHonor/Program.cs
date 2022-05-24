using System;

namespace _07.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printDelegate = PrintSir;

            printDelegate(Console.ReadLine().Split());

        }

        static void PrintSir(string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
