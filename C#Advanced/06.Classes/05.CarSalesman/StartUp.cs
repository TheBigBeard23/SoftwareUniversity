using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string model = data[0];
                int power = int.Parse(data[1]);
                int displacement = 0;
                string efficiency;

                if (data.Length == 3)
                {
                    bool isNumeric = int.TryParse(data[2], out displacement);
                    if (isNumeric)
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        efficiency = data[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (data.Length == 4)
                {
                    displacement = int.Parse(data[2]);
                    efficiency = data[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }

            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string model = data[0];
                Engine engine = engines.Where(x => x.Model == data[1]).FirstOrDefault();
                int weight = 0;
                string color;

                if (data.Length == 3)
                {
                    bool isNumeric = int.TryParse(data[2], out weight);

                    if (isNumeric)
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        color = data[2];
                        cars.Add(new Car(model, engine, color));
                    }

                }
                else if (data.Length == 4)
                {
                    weight = int.Parse(data[2]);
                    color = data[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
