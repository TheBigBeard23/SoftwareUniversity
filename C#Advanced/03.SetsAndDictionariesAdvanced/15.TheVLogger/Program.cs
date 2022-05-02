using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> vloggerFllowers = new Dictionary<string, Dictionary<string, List<string>>>();
            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] data = input.Split();
                string command = data[1];
                string firstName = data[0];
                string secondName = data[2];

                switch (command)
                {
                    case "joined":
                        if (!vloggerFllowers.ContainsKey(firstName))
                        {
                            vloggerFllowers[firstName] = new Dictionary<string, List<string>>();
                            vloggerFllowers[firstName]["fllowers"] = new List<string>();
                            vloggerFllowers[firstName]["fllowing"] = new List<string>();

                        }
                        break;

                    case "followed":
                        if (vloggerFllowers.ContainsKey(secondName) &&
                            vloggerFllowers.ContainsKey(firstName))
                        {
                            if (!vloggerFllowers[secondName]["fllowers"].Contains(firstName) &&
                                firstName != secondName)
                            {
                                vloggerFllowers[secondName]["fllowers"].Add(firstName);
                                vloggerFllowers[firstName]["fllowing"].Add(secondName);
                            }
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerFllowers.Count} vloggers in its logs.");

            int counter = 1;
            foreach (var vlogger in vloggerFllowers.OrderByDescending(x => x.Value["fllowers"].Count).ThenBy(x => x.Value["fllowing"].Count))
            {
                string name = vlogger.Key;
                int fllowersCount = vlogger.Value["fllowers"].Count;
                int fllowingCount = vlogger.Value["fllowing"].Count;

                Console.WriteLine($"{counter}. {name} : {fllowersCount} followers, {fllowingCount} following");

                if (counter == 1)
                {
                    foreach (var fllower in vlogger.Value["fllowers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {fllower}");
                    }
                }

                counter++;
            }

        }
    }
}
