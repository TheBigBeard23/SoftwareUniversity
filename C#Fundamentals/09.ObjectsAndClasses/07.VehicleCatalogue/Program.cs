using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Catalog catalog = new Catalog();

            while (input!="end")
            {

                string[] data = input.Split('/',StringSplitOptions.RemoveEmptyEntries);

                string type = data[0];
                string brand = data[1];
                string model = data[2];           

                if (type == "Car")
                {
                    int horsePower = int.Parse(data[3]);

                    Car car = new Car(brand, model, horsePower);

                    catalog.Cars.Add(car);
                }
                else
                {
                    int weight = int.Parse(data[3]);

                    Truck truck = new Truck(brand, model, weight);

                    catalog.Trucks.Add(truck);
                }

                input = Console.ReadLine();

            }

            Console.WriteLine("Cars:");
            foreach (var veh in catalog.Cars.OrderBy(x=>x.Brand))
            {
                Console.WriteLine($"{veh.Brand}: {veh.Model} - {veh.HorsePower}hp");

            }

            Console.WriteLine("Trucks:");
            foreach (var veh in catalog.Trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{veh.Brand}: {veh.Model} - {veh.Weight}kg");

            }
        }
    }
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand,string model,int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
    }
    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
    }
    public class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }
}