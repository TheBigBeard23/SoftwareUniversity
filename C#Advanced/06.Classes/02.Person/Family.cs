using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            People = new List<Person>();
        }
        public Family(List<Person> people)
            : this()
        {
            People = people;
        }
        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            return People.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public void PrintOlderThan(int age)
        {
            foreach (var person in People.Where(x => x.Age > age)
                                         .OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

    }
}
