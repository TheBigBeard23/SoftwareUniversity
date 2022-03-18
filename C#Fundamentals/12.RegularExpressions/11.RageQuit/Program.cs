using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _11.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(([^0-9]*)([0-9]+))";
            MatchCollection matches = Regex.Matches(input, pattern);
            string message = string.Empty;

            foreach (Match match in matches)
            {
                string crnMessage = match.Groups[2].Value.ToUpper();
                int count = int.Parse(match.Groups[3].Value);

                for (int i = 0; i < count; i++)
                {
                    message += crnMessage;
                }
            }

            Console.WriteLine($"Unique symbols used: {message.Distinct().Count()}");
            Console.WriteLine(message);

        }
    }
}
