using System;
using System.Collections.Generic;

namespace TakeOrSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();

            string text = FilterCharsAndDigits(input, numbers);

            string result = string.Empty;

            int index = 0;

            for (int k = 0; k < numbers.Count; k++)
            {
                if (k % 2 == 0)
                {
                   int counter = 1;

                    for (int i = index; i < text.Length; i++)
                    {
                        if (counter > numbers[k])
                        {
                            break;
                        }

                        result += text[i];
                        index++;
                        counter++;

                    }
                }
                else
                {
                    index += numbers[k];
                }
            }

            Console.WriteLine(result);
            
        }
        static string FilterCharsAndDigits(string input, List<int> numbers)
        {
            string text = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > 47 && input[i] < 58)
                {
                    numbers.Add(int.Parse(input[i].ToString()));
                }
                else
                {
                    text += input[i];
                }
            }
            return text;
        }
    }
}
