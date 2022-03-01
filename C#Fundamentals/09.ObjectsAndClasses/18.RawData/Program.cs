using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            while (count>0)
            {
                string[] input = Console.ReadLine()
                                        .Split()
                                        .ToArray();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);
                cars.Add(car);

                count--;
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.CargoType == "fragile" &&
                                                    x.Cargo.CargoWeight < 1000))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else
            {
                foreach (var car in cars.Where(x => x.Cargo.CargoType == "flamable" &&
                                                    x.Engine.EnginePower > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            
        }
    }
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public Car(string model,Engine engine,Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }
    }
    class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }

        public Engine(int engineSpeed,int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }
    }
    class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int cargoWeight,string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }
    }
}
