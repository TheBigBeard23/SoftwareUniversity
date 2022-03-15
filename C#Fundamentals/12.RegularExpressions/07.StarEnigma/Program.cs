using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> messages = new List<string>();
            Dictionary<string, List<string>> statusPlanets = new Dictionary<string, List<string>>()
            {
                {"Attacked",new List<string>()},
                {"Destroyed",new List<string>()}
            };

            while (n>0)
            {
                string input = Console.ReadLine();
                string lettersPattern = @"[STARstar]";
                int lettersCount = Regex.Matches(input, lettersPattern).Count;
                messages.Add(DecryptMessage(input, lettersCount));

                n--;
            }

            string dataPattern = @"@(?<name>[A-Za-z]+)[^@:!\->]*:(?<population>\d+)[^@:!\->]*!(?<command>[A|D])![^@:!\->]*\->(?<soldier>\d+)[^@:!\->]*";

            for (int i = 0; i < messages.Count; i++)
            {
                Match match = Regex.Match(messages[i], dataPattern);

                if (match.Success)
                {
                    string planetName = match.Groups["name"].Value;
                    string planetStatus = match.Groups["command"].Value;

                    if (planetStatus == "A")
                    {
                        statusPlanets["Attacked"].Add(planetName);
                    }
                    else
                    {
                        statusPlanets["Destroyed"].Add(planetName);
                    }
                    
                }
            }

            Console.WriteLine($"Attacked planets: {statusPlanets.Where(x => x.Key == "Attacked").FirstOrDefault().Value.Count()}");
            List<string> attackedPlanets = statusPlanets.Where(x => x.Key == "Attacked").FirstOrDefault()
                                                .Value
                                                .OrderBy(x => x)
                                                .ToList();
            Print(attackedPlanets);

            Console.WriteLine($"Destroyed planets: {statusPlanets.Where(x => x.Key == "Destroyed").FirstOrDefault().Value.Count()}");
            List<string> destroyedPlanets = statusPlanets.Where(x => x.Key == "Destroyed").FirstOrDefault()
                                               .Value
                                               .OrderBy(x => x)
                                               .ToList();
            Print(destroyedPlanets);

        }

        static string DecryptMessage(string input, int lettersCount)
        {
            string message = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char crnChar = input[i];
                message += (char)(crnChar - lettersCount);
            }

            return message;
        }
        static void Print(List<string> planets)
        {
            
            for (int i = 0; i < planets.Count; i++)
            {
                Console.WriteLine($"-> {planets[i]}");
            }
        }
    }
}
