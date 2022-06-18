using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < count; i++)
            {
                list.Add(Console.ReadLine());
            }

            string value = Console.ReadLine();

            Console.WriteLine(Box.Compare(list, value));
        }
    }
}
