using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();

                if (data.Length > 2)
                {
                    identifiables
                        .Add(new Citizen(data[0], int.Parse(data[1]), data[2]));
                }
                else
                {
                    identifiables
                       .Add(new Robot(data[0], data[1]));
                }
            }
            string fakeId = Console.ReadLine();

            foreach (var identifiable in identifiables)
            {
                if (identifiable.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(identifiable.Id);
                }
            }
        }
    }
}
