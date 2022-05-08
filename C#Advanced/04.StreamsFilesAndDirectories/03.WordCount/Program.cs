using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("../../../words.txt"))
            {
                string[] words = Console.ReadLine()
                                .Split()
                                .Select(x => x.ToLower())
                                .ToArray();

                writer.WriteLine(string.Join(Environment.NewLine, words));
            }

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string text = reader.ReadToEnd();

                CheckWords(text);

            }

        }

        private static void CheckWords(string text)
        {
            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                Dictionary<string, int> wordsCount = new Dictionary<string, int>();

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    string currentWord = reader.ReadLine();

                    while (currentWord != null)
                    {
                        string pattern = @$"\b[{currentWord[0].ToString().ToUpper()}{currentWord[0].ToString().ToLower()}]{currentWord.Remove(0, 1)}\b";
                        MatchCollection matches = Regex.Matches(text,pattern);
                        wordsCount.Add(currentWord, matches.Count);
                        currentWord = reader.ReadLine();
                    }

                    SortWords(wordsCount, writer);
                }
            }
        }

        private static void SortWords(Dictionary<string, int> wordsCount, StreamWriter writer)
        {
            foreach (var word in wordsCount.OrderByDescending(x => x.Value))
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
