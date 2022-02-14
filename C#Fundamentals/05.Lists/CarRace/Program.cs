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

            double leftTime = CalculateTime(numbers, startIndex, endIndex);

            startIndex = endIndex + 1;
            endIndex = numbers.Count;

            double rightTime = CalculateTime(numbers, startIndex, endIndex);

            if (leftTime < rightTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }

        }

        private static double CalculateTime(List<int> numbers, int startIndex,int endIndex)
        {
            double time = 0.0;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (numbers[i] == 0)
                {
                    time *= 0.8;
                }
                else
                {
                    time += numbers[i];
                }
            }

            return time;
        }
    }
}
