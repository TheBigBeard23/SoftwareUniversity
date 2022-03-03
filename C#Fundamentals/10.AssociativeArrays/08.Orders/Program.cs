using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productPrices = new Dictionary<string, decimal>();
            Dictionary<string, int> productQuantities = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

                string name = data[0];
                decimal price = decimal.Parse(data[1]);
                int quantity = int.Parse(data[2]);

                if (!productPrices.ContainsKey(name))
                {
                    productPrices[name] = price;
                    productQuantities[name] = quantity;
                }
                else
                {
                    productPrices[name] = price;
                    productQuantities[name] += quantity;

                }
        
                input = Console.ReadLine();
            }

            foreach (var product in productPrices)
            {
                string productName = product.Key;
                decimal productPrice = product.Value;
                int quantity = productQuantities[productName];

                Console.WriteLine($"{productName} -> {productPrice*quantity:f2}");
            }
            
        }
    }
}
