using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();
            List<string> list= new List<string>();

            if (data.Length > 1)
            {
                for (int i = 1; i < data.Length; i++)
                {
                    list.Add(data[i]);
                }
            }

            int number;
            List<int> numberList = new List<int>();
            if (int.TryParse(list[0], out number))
            {
                numberList = list.Select(int.Parse).ToList();
                var listyIterator = new ListyIterator<int>(numberList);
                ExecuteCommands(listyIterator);
            }
            else
            {
                var listyIterator = new ListyIterator<string>(list);
                ExecuteCommands(listyIterator);
            }

        }
        static void ExecuteCommands<T>(ListyIterator<T> list)
        {
            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        list.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "END":
                        return;
                }
            }
        }
    }
}
