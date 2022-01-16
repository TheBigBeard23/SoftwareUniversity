using System;
using System.Collections.Generic;

namespace DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int symbolsCount = int.Parse(Console.ReadLine());
            List<char> symbols = new List<char>();

            for (int i = 0; i < symbolsCount; i++)
            {
                symbols.Add(char.Parse(Console.ReadLine()));
            }

            foreach (var symbol in symbols)
            {
                Console.Write((char)(symbol+key));
            }
        }
    }
}
