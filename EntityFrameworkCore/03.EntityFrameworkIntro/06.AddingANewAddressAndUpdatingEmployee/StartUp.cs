using _01.DatabaseFirst.Data;
using _01.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace _06.AddingANewAddressAndUpdatingEmployee
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            await AddNewAddressToEmployee(context);
        }

        private async static Task AddNewAddressToEmployee(SoftUniContext context)
        {
            const string AddressText = "Vitoshka 1";
            const int TownId = 4;

            Address newAddress = new Address();
            newAddress.AddressText = AddressText;
            newAddress.TownId = TownId;

            using (context.Database.BeginTransaction())
            {
                context.Addresses.Add(newAddress);

                Employee crnEmployee = await context.Employees
                    .Where(e => e.LastName == "Nakov")
                    .FirstOrDefaultAsync();

                crnEmployee.Address = newAddress;
                context.SaveChanges();

                var addresses = await context.Employees
                    .OrderByDescending(e => e.AddressId)
                    .Select(e => e.Address.AddressText)
                    .Take(10)
                    .ToListAsync();

                PrintResult(addresses);

                context.Database.RollbackTransactionAsync();
            }
        }

        private static void PrintResult(List<string> addresses)
        {
            foreach (var a in addresses)
            {
                Console.WriteLine(a);
            }
        }
    }
}