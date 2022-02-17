using System;

namespace ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] symbols = new char[3];

            for (int i = 1; i <= 3; i++)
            {
                symbols[3 - i] = char.Parse(Console.ReadLine());
            }

            Console.WriteLine(String.Join(" ",symbols));
        }
    }
}
