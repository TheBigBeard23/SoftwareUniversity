using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> sideUsers = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] data = input.Split(" | ").ToArray();
                    string forceSide = data[0];
                    string forceUser = data[1];

                    if (!sideUsers.ContainsKey(forceSide))
                    {
                        sideUsers[forceSide] = new HashSet<string>();
                    }
                    if (sideUsers.Values.Where(x => x.Contains(forceUser)).Count() == 0)
                    {
                        sideUsers[forceSide].Add(forceUser);
                    }

                }

                else
                {
                    string[] data = input.Split(" -> ").ToArray();
                    string forceSide = data[1];
                    string forceUser = data[0];

                    if (sideUsers.Where(x => x.Value.Contains(forceUser) && x.Key != forceSide).Count() > 0)
                    {
                        sideUsers.Where(x => x.Value.Contains(forceUser))
                                 .FirstOrDefault()
                                 .Value
                                 .Remove(forceUser);
                    }

                    if (!sideUsers.ContainsKey(forceSide))
                    {
                        sideUsers[forceSide] = new HashSet<string>();
                    }
                    if (!sideUsers[forceSide].Contains(forceUser))
                    {
                        sideUsers[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }

                input = Console.ReadLine();

            }

            foreach (var side in sideUsers.Where(x => x.Value.Count() > 0)
                                          .OrderByDescending(x => x.Value.Count())
                                          .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count()}");

                foreach (var user in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
