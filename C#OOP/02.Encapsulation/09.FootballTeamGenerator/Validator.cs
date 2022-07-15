using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Validator
    {
        public static void ThrowIfTeamDoesNotExist(string name, List<Team> teams,string exceptionMessage)
        {
            var team = teams.FirstOrDefault(x => x.Name == name);

            if (team == null)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
        public static void ThrowIfNameIsInvalid(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }
        public static void ThrowIfStatsIsOutOfRange
            (int stats, int min, int max, string exceptionMessage)
        {
            if (stats < min || stats > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
