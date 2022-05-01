using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string color = input.Split(" -> ").FirstOrDefault();
                string[] clothes = input.Remove(0, color.Length + 4).Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var wear in clothes)
                {
                    if (!wardrobe[color].ContainsKey(wear))
                    {
                        wardrobe[color][wear] = 0;
                    }

                    wardrobe[color][wear]++;
                }
            }

            string[] clothesData = Console.ReadLine().Split();

            foreach (var color in wardrobe)
            {
                string crnColor = color.Key;

                Console.WriteLine($"{crnColor} clothes:");

                foreach (var clothes in color.Value)
                {
                    string type = clothes.Key;

                    if (crnColor == clothesData[0] &&
                        type == clothesData[1])
                    {
                        Console.WriteLine($"* {type} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {type} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
