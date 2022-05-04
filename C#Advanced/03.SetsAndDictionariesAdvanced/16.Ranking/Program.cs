using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasswords = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userContestPoints = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "end of contests")
            {

                string[] data = input.Split(":").ToArray();
                string contest = data[0];
                string password = data[1];

                if (!contestPasswords.ContainsKey(contest))
                {
                    contestPasswords[contest] = password;
                }

                input = Console.ReadLine();

            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] data = input.Split("=>").ToArray();
                string contest = data[0];
                string password = data[1];
                string name = data[2];
                int points = int.Parse(data[3]);

                if (!contestPasswords.ContainsKey(contest) ||
                    contestPasswords[contest] != password)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!userContestPoints.ContainsKey(name))
                {
                    userContestPoints[name] = new Dictionary<string, int>();
                }
                if (!userContestPoints[name].ContainsKey(contest))
                {
                    userContestPoints[name].Add(contest, points);
                }
                else
                {
                    if (userContestPoints[name][contest] < points)
                    {
                        userContestPoints[name][contest] = points;
                    }
                }

                input = Console.ReadLine();
            }

            var bestCandidate = userContestPoints.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine($"Ranking:");

            foreach (var candidate in userContestPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{candidate.Key}");

                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"# {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
