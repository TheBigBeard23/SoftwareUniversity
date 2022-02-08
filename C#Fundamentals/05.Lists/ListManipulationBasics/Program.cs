using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
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
                var commands = input
                                    .Split()
                                    .ToList();

                string operation = commands[0];

                switch (operation)
                {
                    case "Add":

                        int number = int.Parse(commands[1]);
                        numbers.Add(number);

                        break;

                    case "Remove":

                        number = int.Parse(commands[1]);
                        numbers.Remove(number);

                        break;

                    case "RemoveAt":

                        number = int.Parse(commands[1]);
                        numbers.RemoveAt(number);

                        break;

                    case "Insert":

                        number = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        numbers.Insert(index,number);

                        break;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
       
    }
}
