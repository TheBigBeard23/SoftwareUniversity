using System;

namespace TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string tower = Console.ReadLine();
            string population = Console.ReadLine();
            string area = Console.ReadLine();
            Console.WriteLine($"Town {tower} has population of {population} and area {area} square km.");
        }
    }
}
