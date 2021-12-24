using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermansCount = int.Parse(Console.ReadLine());

            double totalPrice = 0;
            int shipPrice = 0;
            double discount = 0.0;

            switch (season)
            {
                case "Spring":
                    shipPrice = 3000;
                    break;
                case "Summer":
                    shipPrice = 4200;
                    break;
                case "Autumn":
                    shipPrice = 4200;
                    break;
                case "Winter":
                    shipPrice = 2600;
                    break;
                default:
                    break;
            }

            if (fishermansCount <= 6)
            {
                discount = 0.1;
            }
            else if(fishermansCount>=7 && fishermansCount <= 11)
            {
                discount = 0.15;
            }
            else
            {
                discount = 0.25;
            }

            totalPrice = shipPrice;
            totalPrice = totalPrice - totalPrice * discount;

            if (fishermansCount % 2 == 0 && season!= "Autumn")
            {
                totalPrice -= totalPrice * 0.05;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Yes! You have {budget-totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice-budget:f2} leva.");
            }
        }
    }
}
