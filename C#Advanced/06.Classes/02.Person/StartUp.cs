using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //int count = int.Parse(Console.ReadLine());

            //Family family = new Family();

            //for (int i = 0; i < count; i++)
            //{
            //    string[] input = Console.ReadLine().Split();
            //    string name = input[0];
            //    int age = int.Parse(input[1]);

            //    family.AddMember(new Person(name, age));
            //}

            //family.PrintOlderThan(30);

            DateModifier modifier = new DateModifier();

            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            Console.WriteLine(modifier.GetDays(startDate, endDate));
        }
    }
}
