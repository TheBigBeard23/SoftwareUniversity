using _01.DBFirst.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _05.EmployeesFromResearchAndDevelopment
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = await GetEmployeesFromResearchAndDevelopment(context);
            Console.WriteLine(result);

        }
        public static async Task<string> GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            const string DepartmentName = "Research and Development";

            using (context)
            {
                StringBuilder sb = new StringBuilder();
                int departmentId = await context.Departments
                    .Where(d => d.Name == DepartmentName)
                    .Select(d => d.DepartmentId)
                    .FirstOrDefaultAsync();

                var employees = await context.Employees
                    .Where(e => e.DepartmentId == departmentId)
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Salary = e.Salary
                    })
                    .ToListAsync();


                foreach (var e in employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} from {DepartmentName} - ${e.Salary:F2}");
                }

                return sb.ToString().Trim();
            }
        }
    }
}