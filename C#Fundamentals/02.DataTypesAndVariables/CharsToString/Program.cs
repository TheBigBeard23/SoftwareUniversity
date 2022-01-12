using System;

namespace CharsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] symbols = new char[3];

            for (int i = 0; i < 3; i++)
            {
                symbols[i] = char.Parse(Console.ReadLine());
            }

            Console.WriteLine(String.Join("", symbols));
        }
    }
}
