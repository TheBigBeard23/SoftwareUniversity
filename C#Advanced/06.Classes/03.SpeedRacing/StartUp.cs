using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();
                string model = data[1];
                double amountOfKm = double.Parse(data[2]);

                var car = cars.Where(x => x.Model == model).FirstOrDefault();
                car.Drive(amountOfKm);

            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Kilometers}");
            }
        }
    }
}
