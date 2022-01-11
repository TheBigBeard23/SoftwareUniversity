using System;

namespace EnglishNameOfTheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int num = int.Parse(Console.ReadLine());
            int lastNum = num % 10;
            Console.WriteLine(numbers[lastNum]);
        }
    }
}
