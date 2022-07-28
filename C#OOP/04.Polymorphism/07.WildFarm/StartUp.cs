using System;
using System.Collections.Generic;
using WildFarm.Models;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammal;
using WildFarm.Models.Animals.Mammal.Feline;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalData = input.Split();
                Animal animal = CreateAnimal(animalData);
                animals.Add(animal);

                string[] foodData = Console.ReadLine().Split();
                Food food = CreateFood(foodData);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] parts)
        {
            Food food = null;

            string type = parts[0];
            int quantity = int.Parse(parts[1]);

            if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private static Animal CreateAnimal(string[] parts)
        {
            Animal animal = null;

            string name = parts[1];
            double weight = double.Parse(parts[2]);

            string type = parts[0];

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = parts[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = parts[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = parts[3];
                string breed = parts[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = parts[3];
                string breed = parts[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
