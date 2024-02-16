using FoodShortage;
using FoodShortage.Models;

namespace FoosShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length > 3)
                {
                    buyers.Add(GetCitizen(data));
                }
                else
                {
                    buyers.Add(GetRebel(data));
                }
            }

            string buyerName = string.Empty;

            while ((buyerName = Console.ReadLine()) != "End")
            {
                buyers.Where(b => b.Name == buyerName).FirstOrDefault()?.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }

        private static IBuyer GetRebel(string[] data)
        {
            string name = data[0];
            int age = int.Parse(data[1]);
            string group = data[2];

            return new Rebel(name, age, group);
        }

        private static IBuyer GetCitizen(string[] data)
        {
            string name = data[0];
            int age = int.Parse(data[1]);
            string id = data[2];
            string birthdate = data[3];

            return new Citizen(name, age, id, birthdate);

        }
    }
}