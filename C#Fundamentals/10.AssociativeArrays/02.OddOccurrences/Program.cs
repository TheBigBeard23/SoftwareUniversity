using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] words = Console.ReadLine()
                                    .Split()
                                    .ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                if (wordsCount.ContainsKey(words[i]))
                {
                    wordsCount[words[i]]++;
                }
                else
                {
                    wordsCount[words[i]] = 1;
                }
            }

            foreach (var word in wordsCount)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write($"{word.Key.ToLower()} ");
                }
            }
        }
    }
}
