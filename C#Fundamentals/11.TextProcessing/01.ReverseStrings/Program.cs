using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                words.Add(input);

                input = Console.ReadLine();
            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word} = {Reverse(word)}");
            }

        }
        static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}
