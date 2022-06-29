using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SumOfCoins
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> coinsCount = new Dictionary<int, int>();

            int[] coins = Console.ReadLine()
                   .Split(new string[] { "Coins: ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .OrderByDescending(x => x)
                   .ToArray();

            int target = Console.ReadLine()
                .Split("Sum:", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .FirstOrDefault();

            bool targetCompleted = false;

            for (int i = 0; i < coins.Length; i++)
            {
                int currentCoin = coins[i];

                while (target - currentCoin >= 0)
                {
                    target -= currentCoin;

                    if (!coinsCount.ContainsKey(currentCoin))
                    {
                        coinsCount[currentCoin] = 0;
                    }
                    coinsCount[currentCoin]++;
                }

                if (target == 0)
                {
                    targetCompleted = true;
                    break;
                }
            }

            if (targetCompleted)
            {
                Console.WriteLine($"Number of coins to take: {coinsCount.Sum(x => x.Value)}");

                foreach (var coin in coinsCount)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
