using System;

namespace _15.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if(text[i]> first && text[i] < second)
                {
                    sum += text[i];
                }
            }

            Console.WriteLine(sum);

        }
    }
}
