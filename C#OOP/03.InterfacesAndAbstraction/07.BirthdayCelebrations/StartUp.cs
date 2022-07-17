using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();
                string type = data[0];

                if (type != "Robot")
                {
                    switch (type)
                    {
                        case "Citizen":
                            birthables
                                .Add(new Citizen(
                                     data[1],
                                     int.Parse(data[2]),
                                     data[3],
                                     DateTime.ParseExact(data[4], "dd/MM/yyyy", CultureInfo.InvariantCulture)));

                            break;

                        case "Pet":
                            birthables
                                .Add(new Pet(
                                     data[1],
                                     DateTime.ParseExact(data[2], "dd/MM/yyyy", CultureInfo.InvariantCulture)));

                            break;
                    }
                }
            }
            string year = Console.ReadLine();

            foreach (var birthable in birthables.Where(x => x.Birthday.Year.ToString() == year))
            {
                Console.WriteLine(birthable.Birthday.ToString("dd/MM/yyy"));
            }
        }
    }
}
