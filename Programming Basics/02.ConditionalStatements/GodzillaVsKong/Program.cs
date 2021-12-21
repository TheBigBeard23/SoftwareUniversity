using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int extrasCount = int.Parse(Console.ReadLine());
            double suitPrice = double.Parse(Console.ReadLine());

            double decorPrice = movieBudget * 0.10;
            double suitsTotalPrice = extrasCount*suitPrice;
            

            if (extrasCount > 150)
            {
                suitsTotalPrice -= suitsTotalPrice * 0.10;
            }

            double movieTotalPrice = decorPrice + suitsTotalPrice;

            if (movieBudget >= movieTotalPrice)
            {
                Console.WriteLine($"Action!{Environment.NewLine}" +
                                  $"Wingard starts filming with { movieBudget - movieTotalPrice:f2} leva left.");
            }

            else
            {
                Console.WriteLine($"Not enough money!{Environment.NewLine}" +
                                  $"Wingard needs {movieTotalPrice-movieBudget:f2} leva more.");
            }
        }
    }
}
