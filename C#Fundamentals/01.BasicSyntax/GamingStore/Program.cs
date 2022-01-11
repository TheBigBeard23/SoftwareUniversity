using System;
using System.Collections.Generic;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> games = new Dictionary<string, double>()
            {
                { "OutFall 4",                  39.99 },
                { "CS: OG",                     15.99 },
                { "Zplinter Zell",              19.99 },
                { "Honored 2",                  59.99 },
                { "RoverWatch",                 29.99 },
                { "RoverWatch Origins Edition", 39.99 }

            };

            double amount = double.Parse(Console.ReadLine());
            string command;
            double totalSpent = 0.0;

            while ((command = Console.ReadLine())!= "Game Time")
            {
                if (!games.ContainsKey(command))
                {
                    Console.WriteLine("not Found");
                }
                else
                {
                    if (games[command] <= amount)
                    {
                        Console.WriteLine($"Bought {command}");
                        amount -= games[command];
                        totalSpent += games[command];
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

            }

            if (amount == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${amount-totalSpent:f2}");
            }
        }
    }
}
