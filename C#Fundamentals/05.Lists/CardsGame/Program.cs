using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToList();

            List<int> secondHand = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToList();

            while (secondHand.Count > 0 && firstHand.Count > 0)
            {
                int currentCardsFirstHand = firstHand.FirstOrDefault();
                int currentCardsSecondHand = secondHand.FirstOrDefault();

                if (currentCardsFirstHand > currentCardsSecondHand)
                {
                    firstHand.RemoveAt(0);
                    firstHand.Add(currentCardsSecondHand);
                    firstHand.Add(currentCardsFirstHand);
                    secondHand.RemoveAt(0);
                }
                else if (currentCardsFirstHand < currentCardsSecondHand)
                {
                    secondHand.RemoveAt(0);
                    secondHand.Add(currentCardsFirstHand);
                    secondHand.Add(currentCardsSecondHand);
                    firstHand.RemoveAt(0);
                }
                else
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
            }

            if (firstHand.Count > secondHand.Count)
            {
                Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
            }
        }
    }
}
