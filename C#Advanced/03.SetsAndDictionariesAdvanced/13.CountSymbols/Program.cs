using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charsCount = new Dictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char crnChar = text[i];

                if (!charsCount.ContainsKey(crnChar))
                {
                    charsCount[crnChar] = 0;
                }
                charsCount[crnChar]++;
            }

            foreach (var symbol in charsCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
