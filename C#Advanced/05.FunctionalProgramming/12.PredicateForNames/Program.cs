using System;

namespace _12.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> checkLength = n => n.Length <= nameLength;

            foreach (var name in names)
            {
                if (checkLength(name))
                {
                    Console.WriteLine(name);
                }
            }


        }
    }
}
