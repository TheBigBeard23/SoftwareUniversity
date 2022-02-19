using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                List<string> input = Console.ReadLine()
                    .Split()
                    .ToList();

                string name = input[0];

                if (input.Contains("not"))
                {
                    if (guestList.Contains(name))
                    {
                        guestList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    if (guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(name);
                    }
                }

            }

            Console.WriteLine(string.Join(Environment.NewLine,guestList));
        }
    }
}
