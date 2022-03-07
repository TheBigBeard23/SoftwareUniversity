using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorNamesPhysics = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] data = input.Split(" <:> ")
                                     .ToArray();

                string name = data[0];
                string color = data[1];
                int physics = int.Parse(data[2]);

                if (!colorNamesPhysics.ContainsKey(color))
                {
                    colorNamesPhysics[color] = new Dictionary<string, int>();
                }
                if (!colorNamesPhysics[color].ContainsKey(name))
                {
                    colorNamesPhysics[color][name] = physics;
                }
                if (colorNamesPhysics[color][name] < physics)
                {
                    colorNamesPhysics[color][name] = physics;
                }

                input = Console.ReadLine();
            }

            var sortedDwarfs = new Dictionary<string, int>();

            foreach (var color in colorNamesPhysics.OrderByDescending(x => x.Value.Count))                                                
            {             
                foreach (var dwarf in color.Value)
                {
                    sortedDwarfs.Add($"({color.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }

            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value)) 
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }
        }
    }
}
