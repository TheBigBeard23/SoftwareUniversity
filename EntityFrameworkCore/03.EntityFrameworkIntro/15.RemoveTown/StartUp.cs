using _01.DBFirst.Data;
using _01.DBFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace _15.RemoveTown
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            await Console.Out.WriteLineAsync("Which Town do you want to delete?");
            string townName = Console.ReadLine();

            string result = await RemoveTown(context, townName);
            await Console.Out.WriteLineAsync(result);
        }

        private static async Task<string> RemoveTown(SoftUniContext context, string townName)
        {

            using (context.Database.BeginTransactionAsync())
            {
                var addresses = context.Addresses
                    .Where(a => a.Town.Name == townName)
                    .Select(a => new
                    {
                        Address = a,
                        Employees = a.Employees
                    })
                    .ToList();

                foreach (var a in addresses)
                {
                    foreach (var e in a.Employees)
                    {
                        e.Address = null;
                    }
                    context.Addresses.Remove(a.Address);
                }
          

                var town = await context.Towns
                    .Where(t => t.Name == townName)
                    .FirstOrDefaultAsync();

                context.Towns.Remove(town);

                context.SaveChanges();

                await Console.Out.WriteLineAsync("Do you want to save changes? Y/N");

                char choice = char.Parse(Console.ReadLine());

                if (choice == 'Y')
                {
                    context.Database.CommitTransactionAsync();

                    return $"{addresses.Count} addresses in {townName} were deleted";
                }
                else
                {
                    context.Database.RollbackTransactionAsync();

                    return "0 addresses in Seattle were deleted";
                }
            }

        }
    }
}