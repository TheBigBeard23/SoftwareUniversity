using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] data = input.Split();

                string command = data[0];
                string condition = data[1];
                string filter = data[2];

                names = ExecuteOperation(names, checkNames(names, condition, filter), command);

                input = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.Write(string.Join(", ",names));
                Console.Write(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
        static List<string> checkNames(List<string> names,string condition,string filter)
        {
            Func<string, bool> checkNames = x => true;

            switch (condition)
            {
                case "StartsWith":
                    checkNames = x => x.StartsWith(filter);
                    break;

                case "Length":
                    checkNames = x => x.Length == int.Parse(filter);
                    break;

                case "EndsWith":
                    checkNames = x => x.EndsWith(filter);
                    break;
            }

            return names.Where(x => checkNames(x)).ToList();
        }
        static List<string> ExecuteOperation(List<string> names,List<string> targets,string operation)
        {
            List<string> newList = new List<string>();

            if (operation == "Remove")
            {
                foreach (var name in names)
                {
                    if (!targets.Contains(name))
                    {
                        newList.Add(name);
                    }
                }
            }
            else
            {
                foreach (var name in names)
                {
                    newList.Add(name);

                    if (targets.Contains(name))
                    {
                        newList.Add(name);
                    }
                }
            }
            return newList;
        }
    }
}
