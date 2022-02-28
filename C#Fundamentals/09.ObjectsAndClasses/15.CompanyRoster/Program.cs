using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            while (count>0)
            {
                string[] input = Console.ReadLine()
                                        .Split()
                                        .ToArray();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string department = input[2];

                if (!employees.Any(x => x.Name == name))
                {
                    employees.Add(new Employee(name, salary, department));
                }

                count--;
            }

            var highestAvgSalaryDp = employees.GroupBy(x => x.Department)
                                              .OrderByDescending(x => x.Average(x => x.Salary))
                                              .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {highestAvgSalaryDp.Key}");
            foreach (var employee in highestAvgSalaryDp.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
            
        }
    }
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }


        public Employee(string name,decimal salary,string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
    }
}
