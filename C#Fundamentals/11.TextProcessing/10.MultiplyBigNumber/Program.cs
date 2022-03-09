using System;
using System.Collections.Generic;

namespace _10.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Reverse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            string sum = string.Empty;
            int remainder = 0;

            while (firstNumber.Length > 0)
            {
                int currentNum = int.Parse(firstNumber[0].ToString());
                int newNum = (currentNum * multiplier) + remainder;
                firstNumber = firstNumber.Remove(0, 1);
                remainder = 0;

                if (newNum > 9)
                {
                    sum += (newNum % 10).ToString();
                    remainder = newNum / 10;
                }
                else
                {
                    sum += newNum.ToString();
                }

            }

            if (remainder > 0)
            {
                sum += remainder.ToString();
            }

            sum = Reverse(sum).TrimStart('0');
            Console.WriteLine(sum);

        }
        static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;

            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }

            return reverse;
        }
    }
}
