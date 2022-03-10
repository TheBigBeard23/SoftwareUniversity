using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                                   .ToList();

            double sum = 0;

            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                char leftLetter = word[0];
                char rightLetter = word[word.Length - 1];
                double number = double.Parse(word.Substring(1, word.Length - 2));

                if (char.IsUpper(leftLetter))
                {
                    number = number / (leftLetter % 32);
                }
                else
                {
                    number = number * (leftLetter % 32);
                }

                if (char.IsUpper(rightLetter))
                {
                    number = number - (rightLetter % 32);
                }
                else
                {
                    number = number + (rightLetter % 32);
                }

                sum += number;

            }

            Console.WriteLine($"{sum:f2}");

        }
    }
}
