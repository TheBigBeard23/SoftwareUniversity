using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades[name] = new List<decimal>();
                }

                studentGrades[name].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => string.Format("{0:f2}", x)))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
