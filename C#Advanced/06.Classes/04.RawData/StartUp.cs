using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
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

                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                List<Tire> tires = new List<Tire>();
                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);
                tires.Add(new Tire(tire1Age, tire1Pressure));

                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);
                tires.Add(new Tire(tire2Age, tire2Pressure));

                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);
                tires.Add(new Tire(tire3Age, tire3Pressure));

                double tire4Pressure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);
                tires.Add(new Tire(tire4Age, tire4Pressure));

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string filter = Console.ReadLine();

            Predicate<Car> filterPredicate = x => true;

            if (filter == "fragile")
            {
                filterPredicate = x => x.Tires.Any(x => x.Pressure < 1);
                Print(cars, filterPredicate, filter);

            }
            else
            {
                filterPredicate = x => x.Engine.Power > 250;
                Print(cars, filterPredicate, filter);
            }

            static void Print(List<Car> cars, Predicate<Car> predicate, string filter)
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == filter))
                {
                    if (predicate(car))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            }
        }
    }
}
