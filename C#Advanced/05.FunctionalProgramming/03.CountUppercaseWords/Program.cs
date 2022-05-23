using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Where(x => UppercaseWord(x))
                            .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
        static bool UppercaseWord(string word)
        {
            if (char.IsUpper(word[0]))
            {
                return true;
            }

            return false;
        }
    }
}
