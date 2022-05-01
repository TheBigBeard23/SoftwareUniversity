using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] crnElements = Console.ReadLine().Split();

                for (int k = 0; k < crnElements.Length; k++)
                {
                    elements.Add(crnElements[k]);
                }

            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x=>x)));
        }
    }
}
