using System;
using System.Collections.Generic;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            List<string> weekdays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            List<string> weekend = new List<string>() { "Saturday","Sunday" };

            if (weekdays.Contains(day))
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine($"{2.50 * quantity}:f2");
                        break;
                    case "apple":
                        Console.WriteLine($"{1.20 * quantity}:f2");
                        break;
                    case "orange":
                        Console.WriteLine($"{0.85 * quantity}:f2");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{1.45 * quantity}:f2");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{2.70 * quantity}:f2");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{5.50 * quantity}:f2");
                        break;
                    case "grapes":
                        Console.WriteLine($"{3.85 * quantity}:f2");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine($"{2.70 * quantity}:f2");
                        break;
                    case "apple":
                        Console.WriteLine($"{1.25 * quantity}:f2");
                        break;
                    case "orange":
                        Console.WriteLine($"{0.90 * quantity}:f2");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{1.60 * quantity}:f2");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{3.00 * quantity}:f2");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{5.60 * quantity}:f2");
                        break;
                    case "grapes":
                        Console.WriteLine($"{4.20 * quantity:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

        }
    }
}
