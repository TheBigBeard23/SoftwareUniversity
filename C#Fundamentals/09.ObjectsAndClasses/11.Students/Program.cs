using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            while (count>0)
            {
                string[] data = Console.ReadLine()
                                .Split()
                                .ToArray();

                string firstName = data[0];
                string lastName = data[1];
                double grade = double.Parse(data[2]);

                students.Add(new Student(firstName, lastName, grade));

                count--;
            }

            foreach (var student in students.OrderByDescending(x=>x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade}");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName,string lastName,double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
    }

}
