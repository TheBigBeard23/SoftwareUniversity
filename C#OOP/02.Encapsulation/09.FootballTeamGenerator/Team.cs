using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfNameIsInvalid(value);
                name = value;
            }
        }
        public int Rating => players.Count > 0 ? GetRating() : 0;
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            var playerToRemove = players.FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            players.Remove(playerToRemove);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
        private int GetRating()
        {
            return (int)Math.Round(players.Average(x => x.Stats), 0);
        }
    }
}
