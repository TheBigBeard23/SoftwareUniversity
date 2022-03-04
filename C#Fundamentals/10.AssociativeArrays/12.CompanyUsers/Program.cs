using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyEmployees = new Dictionary<string, List<string>>(); 
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split(" -> ")
                                     .ToArray();

                string companyName = data[0];
                string employeeId = data[1];

                if (!companyEmployees.ContainsKey(companyName))
                {
                    companyEmployees[companyName] = new List<string>();
                }
                if (!companyEmployees[companyName].Contains(employeeId))
                {
                    companyEmployees[companyName].Add(employeeId);
                }
                

                input = Console.ReadLine();
            }

            foreach (var company in companyEmployees)
            {
                Console.WriteLine($"{company.Key} \n-- {string.Join("\n-- ",company.Value)}");

            }
        }
    }
}
