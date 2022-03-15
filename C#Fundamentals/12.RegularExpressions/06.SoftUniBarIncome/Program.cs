using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> customersBag = new Dictionary<string, Dictionary<string, double>>();

            string pattern = @"^%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
            double sum = 0.0;
            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    double crnSum = quantity * price;
                    Console.WriteLine($"{name}: {product} - {crnSum:f2}");
                    sum += crnSum;

                    customersBag[name] = new Dictionary<string, double>() { { product, 0.0 } };
                    customersBag[name][product] += quantity * price;
                }
               

                input = Console.ReadLine();
            }
            //Console.WriteLine($"Total income: {sum:f2}");
            //foreach (var customer in customersBag)
            //{
            //    foreach (var product in customer.Value)
            //    {
            //        Console.WriteLine($"{customer.Key}: {product.Key} - {product.Value:f2}");
            //    }
            //}

            Console.WriteLine($"Total income: {customersBag.Values.Select(x=>x.Values.Sum()).Sum():f2}");
        }
    }
}
