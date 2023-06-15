using _01.DBFirst.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _09.Employee147
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = await GetEmployee147(context);
            Console.WriteLine(result);
        }

        private static async Task<string> GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                var employee147 = await context.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle,
                        Projects = e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                    })
                    .FirstOrDefaultAsync();

                sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

                foreach (var p in employee147.Projects.OrderBy(p => p))
                {
                    sb.AppendLine($"{p}");
                }
            }
            return sb.ToString().Trim();
        }
    }
}