using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();
            
            int startIndex = 0;
            int endIndex = numbers.Count / 2;

            decimal leftTime = CalculateTime(numbers, startIndex, endIndex);

            numbers.Reverse();

            decimal rightTime = CalculateTime(numbers, startIndex, endIndex);

            if (leftTime < rightTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }

        }
        private static decimal CalculateTime(List<int> numbers, int startIndex,int endIndex)
        {
            decimal time = 0.0m;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (numbers[i] == 0)
                {
                    time *= 0.8m;
                }            
                    time += numbers[i];
            }

            return time;
        }
    }
}
