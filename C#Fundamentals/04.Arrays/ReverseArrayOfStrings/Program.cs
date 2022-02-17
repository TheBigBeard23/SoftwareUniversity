using System;
using System.Linq;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(' ', Console.ReadLine()
                .Split()
                .Reverse()));
        }
    }
}
