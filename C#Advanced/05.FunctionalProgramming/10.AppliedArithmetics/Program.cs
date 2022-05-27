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
                GetOperation(command, numbers);

                command = Console.ReadLine();
            }
        }

        static void GetOperation(string command, int[] numbers)
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
        }
    }
}
