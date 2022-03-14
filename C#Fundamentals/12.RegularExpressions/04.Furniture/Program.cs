using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<name>[A-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
            List<string> items = new List<string>();
            double sum = 0.0;

            while (input!= "Purchase")
            {
                Match currentMatch = Regex.Match(input,pattern);

                if (currentMatch.Success)
                {
                    string item = currentMatch.Groups["name"].Value;
                    double price = double.Parse(currentMatch.Groups["price"].Value);
                    int quantity = int.Parse(currentMatch.Groups["quantity"].Value);

                    items.Add(item);
                    sum += price * quantity;
                }
              
                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            if (items.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, items));
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
