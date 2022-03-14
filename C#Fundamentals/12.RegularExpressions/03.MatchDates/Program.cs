using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"(?<day>\d{2})([.\-\/])(?<month>[A-Z]{1}[a-z]{2})\1(?<year>\d{4})\b");

            MatchCollection dates = regex.Matches(text);

            foreach (Match date in dates)
            {
                Console.WriteLine($"Day: {date.Groups["day"].Value}, " +
                                  $"Month: {date.Groups["month"].Value}, " +
                                  $"Year: {date.Groups["year"].Value}");
            }
        }
    }
}
