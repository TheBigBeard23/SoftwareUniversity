using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            while (count > 0)
            {
                string[] input = Console.ReadLine()
                                        .Split()
                                        .ToArray();

                string model = input[0];
                decimal fuelAmout = decimal.Parse(input[1]);
                decimal consumptionPerKm = decimal.Parse(input[2]);

                cars.Add(new Car(model, fuelAmout, consumptionPerKm));

                count--;
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] data = command.Split();

                string carModel = data[1];
                int distance = int.Parse(data[2]);

                cars.Where(x => x.Model == carModel)
                    .FirstOrDefault()
                    .Drive(distance);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }
    }
    class Car
    {
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal ConsumptionPerKm { get; set; }
        public int DistanceTraveled { get; set; }
        public Car(string model, decimal fuelAmount, decimal consumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            ConsumptionPerKm = consumptionPerKm;
            DistanceTraveled = 0;
        }

        public void Drive(int distance)
        {
            decimal neededFuel = ConsumptionPerKm * distance;

            if (FuelAmount >= neededFuel)
            {
                FuelAmount -= neededFuel;
                DistanceTraveled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
