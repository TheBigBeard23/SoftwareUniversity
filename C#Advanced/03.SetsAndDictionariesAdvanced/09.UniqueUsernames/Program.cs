using System;
using System.Collections.Generic;

namespace _09.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
