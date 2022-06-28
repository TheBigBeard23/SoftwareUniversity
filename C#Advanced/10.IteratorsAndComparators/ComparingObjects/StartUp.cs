using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] parameters = input.Split();

                string name = parameters[0];
                int age = int.Parse(parameters[1]);
                string town = parameters[2];

                people.Add(new Person(name, age, town));

                input = Console.ReadLine();
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;

            int countEqualPeople = 0;
            int countNonEqualPeople = 0;

            var target = people[personIndex];

            foreach (var person in people)
            {
                if (person.CompareTo(target) == 0)
                {
                    countEqualPeople++;
                }
                else
                {
                    countNonEqualPeople++;
                }
            }

            if (countEqualPeople > 1)
            {
                Console.WriteLine($"{countEqualPeople} {countNonEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }


        }
    }
}
