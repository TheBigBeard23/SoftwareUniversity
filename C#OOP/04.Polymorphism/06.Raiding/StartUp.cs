using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int count = int.Parse(Console.ReadLine());

            while (count > 0)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                count--;

                switch (type)
                {
                    case "Druid":
                        heroes.Add(new Druid(name));
                        break;

                    case "Paladin":
                        heroes.Add(new Paladin(name));
                        break;

                    case "Rogue":
                        heroes.Add(new Rogue(name));
                        break;

                    case "Warrior":
                        heroes.Add(new Warrior(name));
                        break;

                    default:
                        Console.WriteLine("Invalid hero!");
                        count++;
                        break;
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = heroes.Sum(x => x.Power);

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
