using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal britishPound = decimal.Parse(Console.ReadLine());
            decimal dollars = britishPound * 1.31M;
            Console.WriteLine($"{dollars:f3}");
        }
    }
}
