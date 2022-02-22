using System;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            StringRandomize randomizer = new StringRandomize();
            randomizer.words = Console.ReadLine().Split();
            randomizer.Randomize();
            randomizer.PrintWords();
        }

    }
    public class StringRandomize
    {

        public string[] words;

        public void Randomize()
        {
            Random rand = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomPosition = rand.Next(0, words.Length);
                string temp = words[i];
                words[i] = words[randomPosition];
                words[randomPosition] = temp;

            }
        }
        public void PrintWords()
        {
            Console.WriteLine(string.Join(Environment.NewLine,words));
        }
       
    }

          
}
