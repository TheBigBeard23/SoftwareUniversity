using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentCountriesCities =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continentCountriesCities.ContainsKey(continent))
                {
                    continentCountriesCities[continent] = new Dictionary<string, List<string>>();
                }
                if (!continentCountriesCities[continent].ContainsKey(country))
                {
                    continentCountriesCities[continent][country] = new List<string>();
                }
                continentCountriesCities[continent][country].Add(city);

            }

            foreach (var continent in continentCountriesCities)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }


        }
    }
}
