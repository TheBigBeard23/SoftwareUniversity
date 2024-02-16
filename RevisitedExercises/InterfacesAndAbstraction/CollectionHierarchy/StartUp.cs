using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System.Security.Cryptography;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Collection<string>> collections = new List<Collection<string>>();

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            collections.Add(new AddCollection<string>(words.Length));
            collections.Add(new AddRemoveCollection<string>(words.Length));
            collections.Add(new MyList<string>(words.Length));

            int removeOperationCount = int.Parse(Console.ReadLine());

            foreach (var collection in collections)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    Console.Write($"{collection.Add(words[i])} ");
                }
                Console.WriteLine();
            }

            foreach (var collection in collections.Skip(1))
            {
                IRemoveable<string> removeable = (IRemoveable<string>)collection;

                for (int i = 0; i < removeOperationCount; i++)
                {
                    Console.Write($"{removeable.Remove()} ");
                }
                Console.WriteLine();
            }
        }
    }
}