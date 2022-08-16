using System;
using System.Collections.Generic;
using System.Linq;
using VehiclesExtension.Contracts;
using VehiclesExtension.Exceptions;
using VehiclesExtension.Models;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

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
                    else
                    {
                        var distance = double.Parse(commandArguments[2]);

                        Console.WriteLine(vehicles.Where(x => x.GetType().Name == vehicleType)
                                                  .FirstOrDefault()
                                                  .DriveEmpty(distance));
                    }
                }
                catch (Exception ex)
                when (ex is LowFuelException
                   || ex is FuelOutOfTankException
                   || ex is NegativeFuelException)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

        }
        static Vehicle CreateVehicle()
        {
            string[] vehData = Console.ReadLine().Split();
            var typeOfVeh = vehData[0];
            var vehFuelQuantity = double.Parse(vehData[1]);
            var vehLitersPerKm = double.Parse(vehData[2]);
            var vehCapacity = int.Parse(vehData[3]);

            if (typeOfVeh == typeof(Car).Name)
            {
                return new Car(vehFuelQuantity, vehLitersPerKm, vehCapacity);
            }
            else if (typeOfVeh == typeof(Truck).Name)
            {
                return new Truck(vehFuelQuantity, vehLitersPerKm, vehCapacity);
            }
            else
            {
                return new Bus(vehFuelQuantity, vehLitersPerKm, vehCapacity);
            }
        }
    }
}
