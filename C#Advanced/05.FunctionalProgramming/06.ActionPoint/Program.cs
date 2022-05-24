using System;

namespace _06.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Action<string[]> printerDelegate = Printer;

            printerDelegate(words);
        }

        static void Printer(string[] word)
        {
            Console.WriteLine(string.Join(Environment.NewLine,word));
        }
    }
}
