using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            var maxNum = numbers.OrderByDescending(n => n).FirstOrDefault();
            var minNum = numbers.OrderBy(n => n).FirstOrDefault();
            Console.WriteLine($"Max number: {maxNum}");
            Console.WriteLine($"Min number: {minNum}");
        }
    }
}
