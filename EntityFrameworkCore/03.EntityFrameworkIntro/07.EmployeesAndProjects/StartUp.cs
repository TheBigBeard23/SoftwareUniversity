using _01.DatabaseFirst.Data;
using _01.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _07.EmployeesAndProjects
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = await GetEmployeesInPeriod(context);
            Console.WriteLine(result);
        }

        public static async Task<string> GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                var employees = await context.Employees
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        ManagerFirstName = e.Manager.FirstName,
                        ManagerLastName = e.Manager.LastName,
                        Projects = e.Projects.Where(p => p.StartDate.Year >= 2001
                            && p.StartDate.Year <= 2003)


                    })
                    .Take(10)
                    .ToListAsync();


                foreach (var e in employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                    foreach (var p in e.Projects)
                    {
                        sb.AppendLine($"--{p.Name} - {p.StartDate} - {GetEndDate(p.EndDate)}");
                    }
                }

                return sb.ToString().Trim();
            }

        }

        private static object GetEndDate(DateTime? endDate)
        {
            if (endDate == null)
            {
                return "not finished";
            }
            else
            {
                return endDate.Value;
            }
        }
    }
}