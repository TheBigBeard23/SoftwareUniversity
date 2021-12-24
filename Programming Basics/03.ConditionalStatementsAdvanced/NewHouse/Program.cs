using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double priceofFlower = 0;
            double discount = 0;
            double fee = 0;
            double totalPrice = 0.0;

            switch (flowerType)
            {
                case "Roses":
                    priceofFlower = 5;
                    if (flowersCount > 80)
                    {
                        discount = 0.10;

                    }
                    break;
                case "Dahlias":
                    priceofFlower = 3.80;
                    if (flowersCount > 90)
                    {
                        discount = 0.15;


                    }
                    break;
                case "Tulips":
                    priceofFlower = 2.80;
                    if (flowersCount > 80)
                    {
                        discount = 0.15;
                    }
                    break;
                case "Narcissus":
                    priceofFlower = 3;
                    if (flowersCount < 120)
                    {
                        fee = 0.15;

                    }
                    break;
                case "Gladiolus":
                    priceofFlower = 2.50;
                    if (flowersCount < 80)
                    {
                        fee = 0.20;
                    }
                    break;


            }
           totalPrice = (flowersCount * priceofFlower) - (totalPrice * discount) + (totalPrice * fee);
           

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowerType} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");

            }
        }
    }
}
