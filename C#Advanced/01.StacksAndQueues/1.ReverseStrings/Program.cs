using System;
using System.Collections;
using System.Linq;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack text = new Stack();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char crnChar = input[i];
                text.Push(crnChar);
            }

            while (text.Count>0)
            {
                Console.Write(text.Pop());
            }

        }
    }
}
