using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine()
                                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {

                List<string> data = input
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

                string command = data[0];

                switch (command)
                {
                    case "merge":

                        int startIndex = int.Parse(data[1]);
                        int endIndex = int.Parse(data[2]);

                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        if (endIndex >= sequence.Count)
                        {
                            endIndex = sequence.Count - 1;
                        }

                        for (int i = startIndex + 1; i <= endIndex; i++)
                        {
                            sequence[startIndex] += sequence[i];
                            sequence[i] = "[_ _ _]";
                        }

                        sequence.RemoveAll(x => x == "[_ _ _]");

                        break;


                    case "divide":

                        int index = int.Parse(data[1]);
                        int partitions = int.Parse(data[2]);

                        string element = sequence[index];
                        sequence.RemoveAt(index);

                        int newElementsLenght = element.Length / partitions;

                        List<string> subsequences = new List<string>();

                        for (int i = 0; i < partitions; i++)
                        {
                            subsequences.Add(element.Substring(0, newElementsLenght));
                            element = element.Remove(0, newElementsLenght);
                        }

                        if (element.Length > 0)
                        {
                            subsequences[partitions - 1] += element;
                        }

                        sequence.InsertRange(index, subsequences);

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
