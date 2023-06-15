using _01.DBFirst.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _08.AddressesByTown
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = await GetAddressesByTown(context);
            Console.WriteLine(result);  
        }

        private static async Task<string> GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                var addresses = await context.Addresses
                    .Select(a => new
                    {
                        Text = a.AddressText,
                        Town = a.Town.Name,
                        EmployeesCount = a.Employees.Count
                    })
                    .OrderByDescending(a => a.EmployeesCount)
                    .ThenBy(a => a.Town)
                    .ThenBy(a => a.Text)
                    .Take(10)
                    .ToListAsync();

                foreach (var a in addresses)
                {
                    sb.AppendLine($"{a.Text}, {a.Town} - {a.EmployeesCount} employees");
                }

                return sb.ToString().Trim();
            }
        }
    }
}