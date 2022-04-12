using System;
using System.Collections.Generic;
using System.Linq;

namespace _20.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> cups = new Stack<int>(Console.ReadLine().Split()
                                                               .Select(int.Parse)
                                                               .Reverse()
                                                               .ToArray());

            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split()
                                                                  .Select(int.Parse)
                                                                  .ToArray());

            int wastedLitters = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int cup = cups.Peek();
                int bottle = bottles.Pop();

                if (cup <= bottle)
                {
                    cups.Pop();
                    wastedLitters += bottle - cup;
                }
                else
                {
                    cups.Pop();
                    cups.Push(cup - bottle);
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}
