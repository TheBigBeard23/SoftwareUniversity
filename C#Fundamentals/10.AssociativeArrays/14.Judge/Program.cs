using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestUsersPoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> userPoints = new Dictionary<string, int>();

            string input = Console.ReadLine();
            int counter = 1;

            while (input != "no more time")
            {
                string[] data = input.Split(" -> ")
                                     .ToArray();

                string name = data[0];
                string contest = data[1];
                int points = int.Parse(data[2]);

                if (!contestUsersPoints.ContainsKey(contest))
                {
                    contestUsersPoints[contest] = new Dictionary<string, int>();
                }
                if (!contestUsersPoints[contest].ContainsKey(name))
                {
                    contestUsersPoints[contest][name] = 0;
                }
                if (contestUsersPoints[contest][name] < points)
                {
                    contestUsersPoints[contest][name] = points;
                }

                input = Console.ReadLine();
            }

            foreach (var contest in contestUsersPoints)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");


                foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{counter++}. {user.Key} <::> {user.Value}");
                    AddPoints(userPoints, user.Key, user.Value);
                }

                counter = 1;
            }

            Console.WriteLine("Individual standings:");

            foreach (var user in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter++}. {user.Key} -> {user.Value}");
            }
        }
        static void AddPoints(Dictionary<string, int> userPoints, string name, int points)
        {
            if (!userPoints.ContainsKey(name))
            {
                userPoints[name] = 0;
            }

            userPoints[name] += points;
        }
    }
}
