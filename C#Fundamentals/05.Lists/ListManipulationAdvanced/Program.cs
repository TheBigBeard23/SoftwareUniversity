using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
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
            bool isChanged = false;

            while (input!="end")
            {
                var commands = input.Split().ToList();

                string operation = commands[0];

                switch (operation)
                {
                    case "Add":
                        isChanged = true;
                        int number = int.Parse(commands[1]);
                        numbers.Add(number);

                        break;

                    case "Remove":
                        isChanged = true;
                        number = int.Parse(commands[1]);
                        numbers.Remove(number);

                        break;

                    case "RemoveAt":
                        isChanged = true;
                        number = int.Parse(commands[1]);
                        numbers.RemoveAt(number);

                        break;

                    case "Insert":
                        isChanged = true;
                        number = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        numbers.Insert(index, number);

                        break;

                    case "Contains":

                        if (numbers.Contains(int.Parse(commands[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }

                        break;

                    case "PrintEven":

                        PrintEven(numbers);

                        break;

                    case "PrintOdd":

                        PrintOdd(numbers);

                        break;

                    case "GetSum":

                        Console.WriteLine(numbers.Sum());

                        break;

                    case "Filter":

                        string condition = commands[1];
                        number = int.Parse(commands[2]);

                        FilteredPrint(condition, number, numbers);

                        break;
                }

                input = Console.ReadLine();
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ",numbers));
            }

        }

        static void PrintEven(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }

            Console.WriteLine();
        }
        static void PrintOdd(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }

            Console.WriteLine();
        }
        static void FilteredPrint(string condition, int number, List<int> numbers)
        {
            if (condition == ">")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x > number)));
            }
            else if ((condition == ">="))
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x >= number)));
            }
            else if ((condition == "<"))
            {
                Console.WriteLine(string.Join(" ",numbers.Where(x => x < number)));
            }
            else if ((condition == "<="))
            {
                Console.WriteLine(string.Join(" ",numbers.Where(x => x <= number)));
            }
            else if ((condition == "=="))
            {
                Console.WriteLine(string.Join(" ",numbers.Where(x => x == number)));
            }
        }

    }
}
