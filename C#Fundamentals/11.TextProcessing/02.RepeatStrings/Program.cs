using System;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            string result = string.Empty;

            foreach (var word in words)
            {
                result += Repeat(word);
            }

            Console.WriteLine(result);
        }
        static string Repeat(string word)
        {
            string newWord = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                newWord += word;
            }

            return newWord;
        }
    }
}
