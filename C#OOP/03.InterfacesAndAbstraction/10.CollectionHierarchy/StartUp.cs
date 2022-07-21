using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            collections.Add(new MyList());
            collections.Add(new AddRemoveCollection());

            foreach (var collection in collections)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.Write($"{collection.Add(data[i])} ");
                }
                Console.WriteLine();
            }
            foreach (var collection in collections)
            {
                try
                {
                    var removable = (IAddRemoveCollection)(collection);

                    for (int i = 0; i < count; i++)
                    {
                        Console.Write($"{removable.Remove()} ");
                    }
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
