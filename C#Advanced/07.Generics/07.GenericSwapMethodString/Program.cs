using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            int[] indexes = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            Box.Swap<string>(list, indexes[0], indexes[1]);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }

        }
    }
}
