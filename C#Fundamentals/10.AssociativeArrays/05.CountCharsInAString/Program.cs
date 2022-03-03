using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Join("", Console.ReadLine().Split());

            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];

                if (!charsCount.ContainsKey(currentChar))
                {
                    charsCount[currentChar] = 0;
                }

                charsCount[currentChar]++;
            }

            foreach (var symbol in charsCount)
            {
                Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
            }
        }
    }
}
