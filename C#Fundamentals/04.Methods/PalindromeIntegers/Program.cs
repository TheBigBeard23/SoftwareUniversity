using System;
using System.Linq;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            
            while (number!="END")
            {
                Console.WriteLine(CheckDoesNumberArePalindrome(number).ToString().ToLower());

                number = Console.ReadLine();
            }
        }
        static bool CheckDoesNumberArePalindrome(string number)
        {
            string reversedNumber = string.Empty;

            for (int i = number.Length-1; i >= 0; i--)
            {
                reversedNumber += number[i].ToString();
            }

            if (reversedNumber == number)
            {
                return true;
            }

            return false;
        }
    }
}
