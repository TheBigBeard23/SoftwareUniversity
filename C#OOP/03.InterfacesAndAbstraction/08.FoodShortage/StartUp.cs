using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split();
                if (data.Length > 3)
                {
                    people.Add(
                       new Citizen(
                             data[0],
                             int.Parse(data[1]),
                             data[2],
                             data[3]));

                }
                else
                {
                    people.Add(
                        new Rebel(
                            data[0],
                            int.Parse(data[1]),
                            data[2]));
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                if (people.Any(x => x.Name == input))
                {
                    people.FirstOrDefault(x => x.Name == input).BuyFood();
                }
            }
            Console.WriteLine(people.Sum(x => x.Food));
        }
    }
}
