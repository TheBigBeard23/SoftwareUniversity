using System;
using System.Collections.Generic;

namespace _12.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<int> numbers = new HashSet<int>();
            int evenNum = 0;

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numbers.Contains(number))
                {
                    evenNum = number;
                }

                numbers.Add(number);
            }

            Console.WriteLine(evenNum);
        }
    }
}
