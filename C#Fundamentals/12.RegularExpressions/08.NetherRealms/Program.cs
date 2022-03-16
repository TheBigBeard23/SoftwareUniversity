using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _08.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Regex.Split(Console.ReadLine(), @" *,{1} *")
                                      .ToList();

            string healthPattern = @"[^0-9+\-*\/.]";
            string damagePattern = @"-?[0-9]+(\.[0-9+]+)?";

            foreach (var name in names.OrderBy(x=>x))
            {
                MatchCollection healthMatches = Regex.Matches(name, healthPattern);
                MatchCollection damageMatches = Regex.Matches(name, damagePattern);

                int health = GetHealth(healthMatches);
                double damage = GetDamage(damageMatches,name);
                Console.WriteLine($"{name} - {health} health, {damage:f2} damage");
            }       
        }

        static double GetDamage(MatchCollection damageMatches, string name)
        {
            double damage = 0.0;

            foreach (var number in damageMatches)
            {
                damage += double.Parse(number.ToString());
            }

            string operationPattern = @"[\*\/]";
            MatchCollection operations = Regex.Matches(name, operationPattern);

            foreach (var operation in operations)
            {
                if (operation.ToString() == "/")
                {
                    damage /= 2;
                }
                else
                {
                    damage *= 2;
                }
            }

            return damage;
        }

        static int GetHealth(MatchCollection matches)
        {
            int health = 0;
            string match = string.Join("", matches);

            for (int i = 0; i < match.Length; i++)
            {
                health += match[i];
            }

            return health;
        }
    }
}
