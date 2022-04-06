using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split()
                                                                  .Select(int.Parse)
                                                                  .Where(x => x % 2 == 0));

            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
