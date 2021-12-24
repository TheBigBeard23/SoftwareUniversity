using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string place = "";
            double price = 0.0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                place = "Hotel";

                if (season == "summer")
                {
                    price = budget * 0.3;
                }
                else
                {
                    price = budget * 0.7;
                }
            }

            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    place = "Camp";
                }
                else
                {
                    place = "Hotel";
                }

                if (season == "summer")
                {
                    price = budget * 0.4;
                }
                else
                {
                    price = budget * 0.8;
                }

            }
            else
            {
                destination = "Europe";
                place = "Hotel";
                price = budget * 0.9;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {price}");
        }
    }
}
