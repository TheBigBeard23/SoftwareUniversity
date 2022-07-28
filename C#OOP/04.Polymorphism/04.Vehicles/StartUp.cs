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

            string[] carData = Console.ReadLine().Split();
            var carFuelQuantity = double.Parse(carData[1]);
            var carLitersPerKm = double.Parse(carData[2]);
            vehicles.Add(new Car(carFuelQuantity, carLitersPerKm));

            string[] truckData = Console.ReadLine().Split();
            var truckFuelQuantity = double.Parse(truckData[1]);
            var truckLitersPerKm = double.Parse(truckData[2]);
            vehicles.Add(new Truck(truckFuelQuantity, truckLitersPerKm));

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

        }
    }
}
