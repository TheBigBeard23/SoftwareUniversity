using System;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordsCount = int.Parse(Console.ReadLine());
            char[] vowelLetters = new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
            int[] numbers = new int[wordsCount];

            for (int i = 0; i < wordsCount; i++)
            {
                string currentWord = Console.ReadLine();
                int currentNumber = 0;

                for (int k = 0; k < currentWord.Length; k++)
                {
                    char currentLetter = currentWord[k];
                   
                    if (vowelLetters.Contains(currentLetter))
                    {
                        currentNumber += (int)currentLetter * currentWord.Length;
                    }
                    else
                    {
                        currentNumber += (int)currentLetter / currentWord.Length;
                    }
                }

                numbers[i] = currentNumber;

            }

            Console.WriteLine(string.Join(Environment.NewLine,numbers.OrderBy(x=>x)));
        }
    }
}
