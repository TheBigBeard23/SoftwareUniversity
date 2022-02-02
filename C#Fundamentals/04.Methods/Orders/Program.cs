using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            TotalPrice(product, quantity);
        }
        static void TotalPrice(string product,int quantity)
        {
            double sum = 0.0;

            switch (product)
            {
                case "coffee":
                    sum = 1.5 * quantity;
                    break;
                case "water":
                    sum = 1.0 * quantity;
                    break;
                case "coke":
                    sum = 1.4 * quantity;
                    break;
                case "snacks":
                    sum = 2.0 * quantity;
                    break;  
            }

            Console.WriteLine($"{sum:f2}");

        }
    }
}
