using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] field = new int[int.Parse(Console.ReadLine())];

            int[] ladybugsIndexes = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < ladybugsIndexes.Length; i++)
            {
                if(ladybugsIndexes[i]>= 0 &&
                   ladybugsIndexes[i] <= field.Length - 1)
                {
                    field[ladybugsIndexes[i]] = 1;
                }
                
            }

            string input = string.Empty;

            while ((input=Console.ReadLine()).ToLower()!="end")
            {
                string[] commands = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int index = int.Parse(commands[0]);
                string direction = commands[1];
                int value = int.Parse(commands[2]);

                if (index >= 0 && index <= field.Length - 1)
                {
                    field[index] = 0;

                    switch (direction)
                    {
                        case "right":
                            if (value > 0 && index + value <= field.Length - 1)
                            {
                                field[index + value] = 1;
                            }
                            else if (value < 0 && index - value >= 0)
                            {
                                field[index - Math.Abs(value)] = 1;
                            }
                            break;

                        case "left":
                            if (value > 0 && index - value >= 0)
                            {
                                field[index - value] = 1;
                            }
                            else if (value < 0 && index + value <= field.Length)
                            {
                                field[index + Math.Abs(value)] = 1;
                            }
                            break;

                        default:
                            break;
                    }

                }
                
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
