using BorderControl.Contracts;
using BorderControl.Models;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();


                if (data.Length > 2)
                {
                    identifiables.Add(GetCitizen(data));
                }
                else
                {
                    identifiables.Add(GetRobot(data));
                }
            }

            string detainedId = Console.ReadLine();

            foreach (var identifiable in identifiables)
            {
                if (identifiable.Id.EndsWith(detainedId))
                {
                    Console.WriteLine(identifiable.Id);
                }
            }
        }

        private static IIdentifiable GetRobot(string[] data)
        {
            string model = data[0];
            string id = data[1];

            return new Robot(model, id);
        }

        private static IIdentifiable GetCitizen(string[] data)
        {
            string name = data[0];
            int age = int.Parse(data[1]);
            string id = data[2];

            return new Citizen(name, age, id);
        }
    }
}