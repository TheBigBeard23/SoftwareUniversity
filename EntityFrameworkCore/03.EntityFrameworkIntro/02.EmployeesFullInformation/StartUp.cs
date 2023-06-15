using _01.DBFirst.Data;
using _01.DBFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _02.EmployeesFullInformation;
public class StartUp
{
    public static async Task Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();
        string result = await GetEmployeesFullInformation(context);
        Console.WriteLine(result); 
    }
    public static async Task<string> GetEmployeesFullInformation(SoftUniContext context)
    {
        using (context)
        {
            StringBuilder sb = new StringBuilder();

            List<Employee> employees = await context.Employees.ToListAsync();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}