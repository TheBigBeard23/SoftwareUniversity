using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasswords = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userContestsPoints = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] data = input.Split(':')
                                     .ToArray();

                string contest = data[0];
                string password = data[1];

                if (!contestPasswords.ContainsKey(contest))
                {
                    contestPasswords[contest] = password;
                }

                input = Console.ReadLine();
            }

            string submission = Console.ReadLine();

            while (submission != "end of submissions")
            {
                string[] data = submission.Split("=>")
                                          .ToArray();

                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);

                if (contestPasswords.ContainsKey(contest) &&
                   contestPasswords[contest] == password)
                {

                    if (!userContestsPoints.ContainsKey(username))
                    {
                        userContestsPoints[username] = new Dictionary<string, int>();
                    }
                    if (!userContestsPoints[username].ContainsKey(contest))
                    {
                        userContestsPoints[username].Add(contest, points);
                    }
                    else
                    {
                        if (userContestsPoints[username][contest] < points)
                        {
                            userContestsPoints[username][contest] = points;
                        }
                    }
                        
                }

                submission = Console.ReadLine();
            }

            string bestUser = userContestsPoints.OrderBy(x => x.Value.Values.Sum()).Last().Key;
            int bestPoints = userContestsPoints.OrderBy(x => x.Value.Values.Sum()).Last().Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in userContestsPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
