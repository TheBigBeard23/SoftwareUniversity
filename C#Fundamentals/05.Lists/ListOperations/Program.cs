using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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

            while (input!="End")
            {
                List<string> data = input.Split().ToList();

                string command = data[0];

                switch (command)
                {
                    case "Add":

                        int number = int.Parse(data[1]);
                        numbers.Add(number);

                        break;


                    case "Insert":

                        number = int.Parse(data[1]);
                        int index = int.Parse(data[2]);

                        if(index>=0 && index <= numbers.Count)
                        {
                            numbers.Insert(index, number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;


                    case "Remove":

                        index = int.Parse(data[1]);

                        if (index >= 0 && index < numbers.Count)
                        {
                            numbers.RemoveAt(index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;


                    case "Shift":

                        string direction = data[1];
                        int count = int.Parse(data[2]);

                        if (direction == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int lastElement = numbers[numbers.Count - 1];
                                numbers.Insert(0, lastElement);
                                numbers.RemoveAt(numbers.Count - 1);
                            }

                        }

                        break;
             
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
