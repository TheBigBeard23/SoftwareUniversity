using System;
using System.Text.RegularExpressions;

namespace _09.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))";

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (var email in matches)
            {
                Console.WriteLine(email);
            }
        }
    }
}
