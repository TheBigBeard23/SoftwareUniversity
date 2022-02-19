using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();

            GetDigitsSum(numbers);

            string text = Console.ReadLine();

            Console.WriteLine(DecryptMessage(numbers, text));



        }

        static string DecryptMessage(List<int> numbers, string text)
        {
            string result = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                while ((text.Length - 1) < currentNumber)
                {
                    currentNumber -= text.Length;
                }

                result += text[currentNumber + i];

            }

            return result;
        }

        static void GetDigitsSum(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                string currentDigits = numbers[i].ToString();
                int sum = 0;

                for (int k = 0; k < currentDigits.Length; k++)
                {
                    int currentDigit = int.Parse(currentDigits[k].ToString());
                    sum += currentDigit;
                }

                numbers[i] = sum;
            }
        }
    }
}
