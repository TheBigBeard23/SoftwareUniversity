using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseStudents = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input!="end")
            {
                string[] data = input.Split(" : ")
                                     .ToArray();

                string courseName = data[0];
                string studentName = data[1];

                if (!courseStudents.ContainsKey(courseName))
                {
                    courseStudents[courseName] = new List<string>();
                }

                courseStudents[courseName].Add(studentName);

                input = Console.ReadLine();
            }

            foreach (var course in courseStudents)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                Console.WriteLine($"-- {string.Join("\n-- ",course.Value)}");
            }
        }
    }
}
