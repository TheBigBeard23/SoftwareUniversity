using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<int>>> typeDragonsStats = new Dictionary<string, Dictionary<string, List<int>>>();

            int n = int.Parse(Console.ReadLine());

            while (n > 0)
            {
                string[] data = Console.ReadLine().Split()
                                                  .ToArray();

                string type = data[0];
                string name = data[1];
                int[] stats = new int[] { 45, 250, 10 };
                CheckStats(stats, data[2], data[3], data[4]);

                if (!typeDragonsStats.ContainsKey(type))
                {
                    typeDragonsStats[type] = new Dictionary<string, List<int>>();
                }

                typeDragonsStats[type][name] = new List<int>() { stats[0], stats[1], stats[2] };


                n--;
            }

            foreach (var type in typeDragonsStats)
            {
                Console.WriteLine($"{type.Key}::({type.Value.Select(x=>x.Value[0]).Average():f2}/" +
                    $"{type.Value.Select(x => x.Value[1]).Average():f2}/" +
                    $"{type.Value.Select(x => x.Value[2]).Average():f2})");

                foreach (var dragon in type.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }

        private static void CheckStats(int[] stats, string damage, string health, string armor)
        {
            if (damage != "null")
            {
                stats[0] = int.Parse(damage);
            }
            if (health != "null")
            {
                stats[1] = int.Parse(health);
            }
            if (armor != "null")
            {
                stats[2] = int.Parse(armor);
            }
        }
    }
}
