using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinStatsValue = 0;
        private const int MaxStatsValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public double Stats => GetStats();

        private double GetStats()
        {
            return (endurance +
                   sprint +
                   dribble +
                   passing +
                   shooting) / 5.0;

        }

        private int Endurance
        {
            set
            {
                Validator.ThrowIfStatsIsOutOfRange
                    (value, MinStatsValue, MaxStatsValue, $"{nameof(Endurance)} should be between 0 and 100.");
                endurance = value;
            }
        }
        private int Sprint
        {
            set
            {
                Validator.ThrowIfStatsIsOutOfRange
                    (value, MinStatsValue, MaxStatsValue, $"{nameof(Sprint)}should be between 0 and 100.");
                sprint = value;
            }
        }
        private int Dribble
        {
            set
            {
                Validator.ThrowIfStatsIsOutOfRange
                    (value, MinStatsValue, MaxStatsValue, $"{nameof(Dribble)}should be between 0 and 100.");
                dribble = value;
            }
        }
        private int Passing
        {
            set
            {
                Validator.ThrowIfStatsIsOutOfRange
                    (value, MinStatsValue, MaxStatsValue, $"{nameof(Passing)}should be between 0 and 100.");
                passing = value;
            }
        }
        private int Shooting
        {
            set
            {
                Validator.ThrowIfStatsIsOutOfRange
                    (value, MinStatsValue, MaxStatsValue, $"{nameof(Shooting)}should be between 0 and 100.");
                shooting = value;
            }
        }




    }
}
