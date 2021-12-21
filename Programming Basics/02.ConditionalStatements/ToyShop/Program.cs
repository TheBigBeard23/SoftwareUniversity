using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripCost = double.Parse(Console.ReadLine());

            int puzzlesCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int bearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            int toysTotalCount = puzzlesCount + dollsCount + bearsCount +
                                 minionsCount + trucksCount;

            double totalSum = puzzlesCount * 2.60 +
                              dollsCount * 3.00 +
                              bearsCount * 4.10 +
                              minionsCount * 8.20 +
                              trucksCount * 2.00;
            if (toysTotalCount >= 50)
            {
                totalSum -= totalSum * 0.25;
            }
            totalSum -= totalSum * 0.1;

            if (totalSum >= tripCost)
            {
                Console.WriteLine($"Yes! {totalSum - tripCost:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripCost - totalSum:f2} lv needed.");
            }


        }
    }
}

