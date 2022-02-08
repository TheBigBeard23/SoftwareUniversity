using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> ithems = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                ithems.Add(Console.ReadLine());
            }

            PrintSortedItems(ithems);
        }
        static void PrintSortedItems(List<string> ithems)
        {
            int counter = 1;

            foreach (var item in ithems.OrderBy(x=>x))
            {
                Console.WriteLine($"{counter}.{item}");
                counter++;
            }
        }
    }
}
