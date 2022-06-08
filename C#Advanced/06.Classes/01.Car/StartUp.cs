using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                double[] tiresData = input.Split()
                                     .Select(double.Parse)
                                     .ToArray();

                Tire[] crnTires = new Tire[4];

                int counter = 0;
                for (int i = 0; i < tiresData.Length; i += 2)
                {
                    crnTires[counter] = new Tire((int)tiresData[i], tiresData[i + 1]);
                    counter++;
                }

                tires.Add(crnTires);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                double[] engineData = input.Split()
                                     .Select(double.Parse)
                                     .ToArray();

                engines.Add(new Engine((int)engineData[0], engineData[1]));
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carData = input.Split();

                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQunatity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                Engine engine = engines[int.Parse(carData[5])];
                Tire[] carTires = tires[int.Parse(carData[6])];

                cars.Add(new Car(make, model, year, fuelQunatity, fuelConsumption, engine, carTires));
            }

            StringBuilder sb = new StringBuilder();

            foreach (var car in cars.Where(x => x.Year >= 2017)
                                    .Where(x => x.Engine.HorsePower > 330)
                                    .Where(x => x.Tires.Sum(x => x.Pressure) > 9 &&
                                                x.Tires.Sum(x => x.Pressure) < 10))
            {
                car.Drive(20);

                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"Year: {car.Year}");
                sb.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                sb.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }

            Console.WriteLine(sb);

        }
    }
}
