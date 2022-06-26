using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var createCommand = Console.ReadLine()
               .Split(new string[] { "Create", " " }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            var listyIterator = new ListyIterator<string>(createCommand);

            string input = Console.ReadLine();

            while (input!="END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "Print":
                        listyIterator.Print();
                        break;

                    case "PrintAll":

                        foreach (var item in listyIterator)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                        break;

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;

                }

                input = Console.ReadLine();
            }
        }
    }
}