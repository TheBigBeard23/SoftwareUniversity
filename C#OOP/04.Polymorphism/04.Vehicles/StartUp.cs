using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Contracts;
using Vehicles.Exceptions;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            vehicles.Add(CreateVeh());
            vehicles.Add(CreateVeh());

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    var commandArguments = Console.ReadLine()
                    .Split()
                    .ToArray();

                    var command = commandArguments[0];
                    var vehicleType = commandArguments[1];

                    if (command == "Drive")
                    {
                        var distance = double.Parse(commandArguments[2]);

                        Console.WriteLine(vehicles.Where(x => x.GetType().Name == vehicleType)
                                                  .FirstOrDefault()
                                                  .Drive(distance));
                    }
                    else if (command == "Refuel")
                    {
                        var liters = double.Parse(commandArguments[2]);

                        vehicles.Where(x => x.GetType().Name == vehicleType)
                                .FirstOrDefault()
                                .Refuel(liters);
                    }
                }
                catch (FuelExceptions lfe)
                {
                    Console.WriteLine(lfe.Message);
                    continue;
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
            ;
        }
        private static IVehicle CreateVeh()
        {
            string[] vehData = Console.ReadLine().Split();
            var typeOfVeh = vehData[0];
            double vehFuelQuantity = double.Parse(vehData[1]);
            double vehLitersPerKm = double.Parse(vehData[2]);

            if (typeOfVeh == typeof(Car).Name)
            {
                return new Car(vehFuelQuantity, vehLitersPerKm);
            }
            else
            {
                return new Truck(vehFuelQuantity, vehLitersPerKm);
            }
        }
    }
}
