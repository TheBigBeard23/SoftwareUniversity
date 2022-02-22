using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] data = input.Split();

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string homeTown = data[3];

                Student currentStudent = new Student(firstName, lastName, age, homeTown);

                RemoveStudentIfExist(students, currentStudent);

                students.Add(currentStudent);

                input = Console.ReadLine();
            }

            string town = Console.ReadLine();

            foreach (var student in students.Where(x => x.HomeTown == town))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        private static void RemoveStudentIfExist(List<Student> students, Student currentStudent)
        {
            foreach (var student in students.ToList())
            {
                if(student.FirstName==currentStudent.FirstName &&
                    student.LastName == currentStudent.LastName)
                {
                    students.Remove(student);
                }
            }
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }
    }
}
