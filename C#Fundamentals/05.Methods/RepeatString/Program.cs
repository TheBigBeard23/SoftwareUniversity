using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine(StringCreator(word,count));
        }
        static string StringCreator(string word,int count)
        {
            string newWord = string.Empty;

            for (int i = 0; i < count; i++)
            {
                newWord += word;
            }

            return newWord;
        }
    }
}
