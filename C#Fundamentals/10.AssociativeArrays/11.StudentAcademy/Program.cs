using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studensGrade = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            while (n > 0)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studensGrade.ContainsKey(name))
                {
                    studensGrade[name] = new List<double>();
                }

                studensGrade[name].Add(grade);

                n--;
            }

            foreach (var student in studensGrade.Where(x => x.Value.Average() >= 4.5))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
