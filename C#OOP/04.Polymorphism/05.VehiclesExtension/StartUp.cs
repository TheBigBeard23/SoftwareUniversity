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

            CreateCar(vehicles);
            CreateTruck(vehicles);
            CreateBus(vehicles);

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
                catch (LowFuelException lfe)
                {
                    Console.WriteLine(lfe.Message);
                    continue;
                }
                catch (FuelOutOfTankException foote)
                {
                    Console.WriteLine(foote.Message);
                    continue;
                }
                catch (NegativeFuelException nfe)
                {
                    Console.WriteLine(nfe.Message);
                    continue;
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

        }
        static void CreateCar(List<IVehicle> vehicles)
        {
            string[] carData = Console.ReadLine().Split();
            var carFuelQuantity = double.Parse(carData[1]);
            var carLitersPerKm = double.Parse(carData[2]);
            var tankCapacity = int.Parse(carData[3]);
            vehicles.Add(new Car(carFuelQuantity, carLitersPerKm, tankCapacity));
        }
        static void CreateTruck(List<IVehicle> vehicles)
        {
            string[] truckData = Console.ReadLine().Split();
            var truckFuelQuantity = double.Parse(truckData[1]);
            var truckLitersPerKm = double.Parse(truckData[2]);
            var tankCapacity = int.Parse(truckData[3]);
            vehicles.Add(new Truck(truckFuelQuantity, truckLitersPerKm, tankCapacity));
        }
        static void CreateBus(List<IVehicle> vehicles)
        {
            string[] busData = Console.ReadLine().Split();
            var busFuelQuantity = double.Parse(busData[1]);
            var busLitersPerKm = double.Parse(busData[2]);
            var tankCapacity = int.Parse(busData[3]);
            vehicles.Add(new Bus(busFuelQuantity, busLitersPerKm, tankCapacity));
        }
    }
}
