using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family();

            while (count>0)
            {
                string[] input = Console.ReadLine()
                                        .Split()
                                        .ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);

                family.AddMember(new Person(name, age));

                count--;
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Family
    {
        public List<Person> Persons { get; set; }

        public Family()
        {
            Persons = new List<Person>();
        }

        public void AddMember(Person member)
        {
            Persons.Add(member);
        }
        public Person GetOldestMember()
        {
            return Persons.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
