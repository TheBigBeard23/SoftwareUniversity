using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Console.WriteLine(GetMiddleCharacter(word));
        }
        static string GetMiddleCharacter(string word)
        {
            string characters = string.Empty;

            if (word.Length % 2 == 1)
            {
                characters = word[word.Length / 2].ToString();
            }
            else
            {
                characters += word[word.Length / 2 - 1].ToString();
                characters += word[word.Length / 2].ToString();
            }

            return characters;

            
        }
    }
}
