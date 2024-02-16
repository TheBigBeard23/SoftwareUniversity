using BirthdayCelebration.Contracts;
using BirthdayCelebration.Models;

namespace BirthdayCelebration
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<IBirthable> birthables = new List<IBirthable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();


                if (data[0] == "Citizen")
                {
                    birthables.Add(GetCitizen(data));
                }
                else if (data[0] == "Pet")
                {
                    birthables.Add(GetPet(data));
                }
            }
            
            string birthYear = Console.ReadLine();

            foreach (var birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(birthYear))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }

        private static IBirthable GetPet(string[] data)
        {
            string name = data[1];
            string birthdate = data[2];

            return new Pet(name, birthdate);
        }

        private static IBirthable GetCitizen(string[] data)
        {
            string name = data[1];
            int age = int.Parse(data[2]);
            string id = data[3];
            string birthdate = data[4];

            return new Citizen(name, age, id, birthdate);
        }
    }
}