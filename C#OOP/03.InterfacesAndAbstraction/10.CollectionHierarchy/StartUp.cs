using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Collection> collections = new List<Collection>();
            string[] data = Console.ReadLine().Split();
            int count = int.Parse(Console.ReadLine());

            collections.Add(new AddCollection());
            collections.Add(new AddRemoveCollection());
            collections.Add(new MyList());

            foreach (var collection in collections)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write($"{collection.Add(data[i])} ");
                }
                Console.WriteLine();
            }
        }
    }
}
