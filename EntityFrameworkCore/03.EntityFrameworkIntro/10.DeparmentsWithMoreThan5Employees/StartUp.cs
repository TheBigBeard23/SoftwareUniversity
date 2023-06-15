using _01.DBFirst.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _10.DeparmentsWithMoreThan5Employees
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = await GetDepartmentsWithMoreThan5Employees(context);
            Console.WriteLine(result);
        }

        private static async Task<string> GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                var departments = await context.Departments
                    .Where(d => d.Employees.Count > 5)
                    .Select(d => new
                    {
                        DepartmentName = d.Name,
                        ManagerFirstName = d.Manager.FirstName,
                        ManagerLastName = d.Manager.LastName,
                        Employees = d.Employees.Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobTitle = e.JobTitle
                        })
                    })
                    .OrderBy(d => d.Employees.Count())
                    .ThenBy(d => d.DepartmentName)
                    .ToListAsync();

                foreach (var d in departments)
                {
                    sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                    foreach (var e in d.Employees
                                                 .OrderBy(e => e.FirstName)
                                                 .ThenBy(e => e.LastName))
                    {
                        sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}