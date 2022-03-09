using System;

namespace _07.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            int sum = 0;
            string firstWord = words[0];
            string secondWord = words[1];

            while (firstWord.Length > 0 && secondWord.Length > 0)
            {
                sum += firstWord[0] * secondWord[0];

                firstWord = firstWord.Remove(0, 1);
                secondWord = secondWord.Remove(0, 1);

            }

            if (firstWord.Length>0)
            {
                sum += SumChar(firstWord);
            }

            else if (secondWord.Length > 0)
            {
                sum += SumChar(secondWord);
            }

            Console.WriteLine(sum);
        }

        static int SumChar(string word)
        {
            int sum = 0;

            while (word.Length>0)
            {
                sum += word[0];

                word = word.Remove(0, 1);
            }

            return sum;
        }
    }
}
