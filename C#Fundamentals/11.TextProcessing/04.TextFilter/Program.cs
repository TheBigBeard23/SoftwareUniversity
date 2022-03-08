using System;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                text = Replace(bannedWords[i], text);
            }

            Console.WriteLine(text);
        }
        static string Replace(string banWord, string text)
        {
            string replacement = new string('*', banWord.Length);

            while (text.Contains(banWord))
            {
                text = text.Replace(banWord, replacement);
            }

            return text;
        }
    }
}
