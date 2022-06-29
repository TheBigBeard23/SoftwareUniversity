using System;
using System.Collections.Generic;

namespace EqualityLogic
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            var hashSet = new HashSet<Person>();
            var sortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                var person = new Person(name, age);

                hashSet.Add(person);
                sortedSet.Add(person);

            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);

        }
    }
}
