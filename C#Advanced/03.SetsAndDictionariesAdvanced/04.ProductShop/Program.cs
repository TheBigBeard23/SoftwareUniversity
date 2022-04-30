using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopProductsPrice = new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(", ");

            while (input[0] != "Revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shopProductsPrice.ContainsKey(shop))
                {
                    shopProductsPrice[shop] = new Dictionary<string, double>();
                }

                shopProductsPrice[shop][product] = price;

                input = Console.ReadLine().Split(", ");
            }

            foreach (var shop in shopProductsPrice.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }

            }
        }
    }
}
