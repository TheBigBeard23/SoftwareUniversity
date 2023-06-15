using System.Text;

namespace _13.FindEmployeesByFirstNameStartingWith
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string input = Console.ReadLine();
            string result = await GetEmployeesByFirstNameStartingWithSa(context, input);
            await Console.Out.WriteLineAsync(result);

        }

        private static async Task<string> GetEmployeesByFirstNameStartingWithSa(SoftUniContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                var employees = await context.Employees
                    .Where(p => p.FirstName.StartsWith(input))
                    .ToListAsync();

                foreach (var e in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
                }
            }

            return sb.ToString().Trim();
        }
    }
}