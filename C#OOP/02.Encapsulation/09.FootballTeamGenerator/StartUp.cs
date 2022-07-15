using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] data = input
                        .Split(";", StringSplitOptions.RemoveEmptyEntries);

                    string command = data[0];
                    string teamName = data[1];

                    switch (command)
                    {
                        case "Team":

                            teams.Add(new Team(teamName));

                            break;

                        case "Add":
                            string playerName = data[2];
                            int endurance = int.Parse(data[3]);
                            int sprint = int.Parse(data[4]);
                            int dribble = int.Parse(data[5]);
                            int passing = int.Parse(data[6]);
                            int shooting = int.Parse(data[7]);

                            Validator.ThrowIfTeamDoesNotExist
                                (teamName, teams, $"Team {teamName} does not exist.");

                            teams
                                .FirstOrDefault(x => x.Name == teamName)
                                .AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));

                            break;

                        case "Remove":
                            playerName = data[2];

                            Validator.ThrowIfTeamDoesNotExist
                                (teamName, teams, $"Team {teamName} does not exist.");

                            teams.FirstOrDefault(x => x.Name == teamName).RemovePlayer(playerName);

                            break;

                        case "Rating":

                            Validator.ThrowIfTeamDoesNotExist
                               (teamName, teams, $"Team {teamName} does not exist.");

                            Console.WriteLine(teams.FirstOrDefault(x => x.Name == teamName));

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
