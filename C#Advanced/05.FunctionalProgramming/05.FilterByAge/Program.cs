using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> namesAge = new Dictionary<string, int>();

            int count = int.Parse(Console.ReadLine());
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine()
                               .Split(", ")
                               .ToArray();

                string name = data[0];
                int age = int.Parse(data[1]);

                people[i] = new Person()
                {
                    Name = name,
                    Age = age
                };

            }

            string condition = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionDelegate = GetCondition(condition, filterAge);
            Action<Person> printDelegate = GetPrinter(format);

            foreach (var person in people)
            {
                if (conditionDelegate(person))
                {
                    printDelegate(person);
                }
            }

        }

        static Func<Person, bool> GetCondition(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return p => p.Age <= age;
                case "older": return p => p.Age >= age;

                default: return null;
            }
        }

        static Action<Person> GetPrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => 
                    { 
                        Console.WriteLine($"{p.Name}"); 
                    };

                case "age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Age}");
                    };

                case "name age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Name} - {p.Age}");
                    };

                default:
                    return null;

            }
        }
    }
}
