using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Citizen> citizens = new List<Citizen>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                string country = info[1];
                int age = int.Parse(info[2]);

                citizens.Add(new Citizen(name, country, age));
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }

        }
    }
}