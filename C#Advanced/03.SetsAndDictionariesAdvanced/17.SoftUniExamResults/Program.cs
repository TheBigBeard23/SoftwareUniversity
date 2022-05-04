using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> userLanguagePoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] data = input.Split("-").ToArray();
                string name = data[0];
                string language = data[1];

                if (language == "banned")
                {
                    userLanguagePoints.Remove(name);
                    input = Console.ReadLine();
                    continue;
                }

                int points = int.Parse(data[2]);

                if (!languageSubmissions.ContainsKey(language))
                {
                    languageSubmissions[language] = 0;
                }

                languageSubmissions[language]++;

                if (!userLanguagePoints.ContainsKey(name))
                {
                    userLanguagePoints[name] = new Dictionary<string, int>();
                }
                if (!userLanguagePoints[name].ContainsKey(language))
                {
                    userLanguagePoints[name].Add(language, points);
                }
                if (userLanguagePoints[name][language] < points)
                {
                    userLanguagePoints[name][language] = points;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var user in userLanguagePoints.OrderByDescending(x => x.Value.Values.Sum())
                                                   .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value.Values.Sum()}");
            }

            Console.WriteLine("Submissions:");

            foreach (var submission in languageSubmissions.OrderByDescending(x => x.Value)
                                                          .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
