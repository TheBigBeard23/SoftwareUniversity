using System.Text;

namespace _11.FindLatest10Projects
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = await GetLatestProjects(context);
            await Console.Out.WriteLineAsync(result);
        }

        private static async Task<string> GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                var projects = await context.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Description = p.Description,
                        StartDate = p.StartDate
                    })
                    .Take(10)
                    .ToListAsync();

                foreach (var p in projects.OrderBy(p => p.Name))
                {
                    sb.AppendLine($"{p.Name}");
                    sb.AppendLine($"{p.Description}");
                    sb.AppendLine($"{p.StartDate}");
                    sb.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                }

            }
            return sb.ToString().Trim();

        }
    }
}