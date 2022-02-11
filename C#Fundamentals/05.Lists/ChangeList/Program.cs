using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> data = input.Split().ToList();
                string command = data[0];

                switch (command)
                {
                    case "Delete":

                        int ithem = int.Parse(data[1]);
                        Delete(numbers, ithem);

                        break;

                    case "Insert":

                        ithem = int.Parse(data[1]);
                        int index = int.Parse(data[2]);
                        Insert(numbers, ithem, index);

                        break;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
        static void Delete(List<int> ithems, int ithem)
        {
            if (ithems.Contains(ithem))
            {
                ithems.Remove(ithem);
            }
        }
        static void Insert(List<int> ithems, int ithem, int position)
        {
            if (ithems.Count > position &&
                position >= 0)
            {
                ithems.Insert(position, ithem);
            }
        }
    }
}
