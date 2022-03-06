using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerPositionsSkills = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input!="Season end")
            {

                string[] data = input.Split(new string[] { " -> ", " " }, StringSplitOptions.RemoveEmptyEntries);

                string player = data[0];
                string position = data[1];


                if (position == "vs")
                {
                    string secondPlayer = data[2];

                    Fight(playerPositionsSkills, player, secondPlayer);
                }
                else
                {
                    int skill = int.Parse(data[2]);

                    SavePlayer(playerPositionsSkills, player, position, skill);
                }

                input = Console.ReadLine();
            }

            foreach (var player in playerPositionsSkills.OrderByDescending(x => x.Value.Values.Sum())
                                                        .ThenBy(x => x.Key)
                                                        .Where(x => x.Value.Keys.Count > 0))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var position in player.Value.OrderByDescending(x => x.Value)
                                                     .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }

        private static void Fight(Dictionary<string, Dictionary<string, int>> playerPositionsSkills, string player, string secondPlayer)
        {
            if (playerPositionsSkills.ContainsKey(player) &&
                playerPositionsSkills.ContainsKey(secondPlayer))
            {
                foreach (var positions in playerPositionsSkills.Where(x => x.Key == player))
                {
                    foreach (var crnPosition in positions.Value)
                    {
                        string currentPosition = crnPosition.Key;

                        if (playerPositionsSkills[secondPlayer].ContainsKey(crnPosition.Key))
                        {

                            if (playerPositionsSkills[player][currentPosition] > playerPositionsSkills[secondPlayer][currentPosition])
                            {
                                playerPositionsSkills[secondPlayer].Remove(currentPosition);
                            }
                            else
                            {
                                playerPositionsSkills[player].Remove(currentPosition);
                            }

                        }
                    }
                }
            }
        }

        private static void SavePlayer(Dictionary<string, Dictionary<string, int>> playerPositionsSkills, string player, string position, int skill)
        {
            if (!playerPositionsSkills.ContainsKey(player))
            {
                playerPositionsSkills[player] = new Dictionary<string, int>();
            }
            if (!playerPositionsSkills[player].ContainsKey(position))
            {
                playerPositionsSkills[player][position] = skill;
            }
            if (playerPositionsSkills[player][position] < skill)
            {
                playerPositionsSkills[player][position] = skill;
            }
        }
    }
}
