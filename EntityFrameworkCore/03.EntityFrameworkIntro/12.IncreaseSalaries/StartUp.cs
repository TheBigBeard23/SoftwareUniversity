using _01.DatabaseFirst.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _12.IncreaseSalaries
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = await IncreaseSalaries(context);
            await Console.Out.WriteLineAsync(result);
        }

        private static async Task<string> IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                var employees = await context.Employees
                    .Where(e => e.Department.Name == "Engineering"
                             || e.Department.Name == "Tool Design"
                             || e.Department.Name == "Marketing"
                             || e.Department.Name == "Information Services")
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Salary = e.Salary * 1.12M
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToListAsync();

                foreach (var e in employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
                }
            }

            return sb.ToString().Trim();
        }

    }
}