using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> guests = new HashSet<string>();

            while (input != "PARTY")
            {
                guests.Add(input);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                guests.Remove(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            if (guests.Where(x => Char.IsDigit(x[0])).Count() > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, guests.Where(x => Char.IsDigit(x[0]))));
            }
            if (guests.Where(x => Char.IsLetter(x[0])).Count() > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, guests.Where(x => Char.IsLetter(x[0]))));
            }

        }

    }
}
