using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();

            while (secondWord.Contains(firstWord))
            {
                secondWord = secondWord.Replace(firstWord, "");
            }

            Console.WriteLine(secondWord);
        }
    }
}
