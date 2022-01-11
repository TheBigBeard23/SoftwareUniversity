using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = 0;
            string input;

            while ((input=Console.ReadLine())!="Start")
            {
                double currentAmount = double.Parse(input);

                if (currentAmount != 1 &&
                    currentAmount != 2 &&
                    currentAmount != 0.1 &&
                    currentAmount != 0.2 &&
                    currentAmount != 0.5)
                {
                    Console.WriteLine($"Cannot accept {currentAmount}");
                }
                else
                {
                    amount += currentAmount;
                }
            }

            string product;

            while ((product=Console.ReadLine())!="End")
            {
                double price = 0;

                switch (product)
                {
                    case "Nuts":
                        price = 2.0;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1.0;
                        break;

                    default:
                        Console.WriteLine("Invalid product");
                        continue;
                        
                }

                if (amount >= price)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    amount -= price;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

            }


            Console.WriteLine($"Change: {amount:f2}");

        }
    }
}
