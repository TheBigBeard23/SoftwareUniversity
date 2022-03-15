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
  
            string pattern = @"^%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
            double totalSum = 0.0;
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
                    double sum = quantity * price;

                    Console.WriteLine($"{name}: {product} - {sum:f2}");

                    totalSum += sum;

                }          

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");

        }
    }
}
