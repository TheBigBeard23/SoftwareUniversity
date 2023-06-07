using _01.DatabaseFirst.Data;
using _01.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _04.EmployeesWithSalaryOver50000;

public class StartUp
{
    static async Task Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();
        string result = await GetEmployeesWithSalaryOver50000(context);
        Console.WriteLine(result);

    }
    public static async Task<string> GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        using (context)
        {
            StringBuilder sb = new StringBuilder();

            List<Employee> employees = await context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToListAsync();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

    }
}
