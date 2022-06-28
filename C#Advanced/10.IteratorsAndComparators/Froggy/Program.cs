using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stones = Console.ReadLine()
                         .Split(", ")
                         .Select(int.Parse)
                         .ToArray();

            Lake lake = new Lake(stones);

            int[] path = new int[stones.Length];
            int counter = 0;

            foreach (var stone in lake)
            {
                if (stone % 2 == 1)
                {
                    path[counter] = stone;
                    counter++;
                }
                else
                {
                    path[(stones.Length - 1) - (counter - 1)] = stone;
                }
            }

            Console.WriteLine(string.Join(", ", path));
        }
    }
}
