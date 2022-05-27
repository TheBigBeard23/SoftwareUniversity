using System;
using System.Linq;

namespace _10.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x => x + 1).ToArray();
                        break;

                    case "multiply":
                        numbers = numbers.Select(x => x * 1).ToArray();
                        break;

                    case "subtract":
                        numbers = numbers.Select(x => x - 1).ToArray();
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;

                }

                command = Console.ReadLine();
            }
        }
    }
}
