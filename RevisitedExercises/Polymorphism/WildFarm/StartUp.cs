using System.Reflection;
using WildFarm.Contracts;
using WildFarm.Models;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Feline;

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
                string[] data = input.Split();

                string animalType = data[0];

                if (animalType == "Cat" ||
                    animalType == "Tiger")
                {
                    CreateFeline(animals, data, animalType);
                }
                else if (animalType == "Hen" ||
                         animalType == "Owl")
                {
                    CreateBird(animals, data, animalType);
                }
                else if (animalType == "Dog" ||
                        animalType == "Mouse")
                {
                    CreateMammal(animals, data, animalType);
                }

                string[] foodInfo = Console.ReadLine().Split();

                Type foodType = Type.GetType("WildFarm.Models.Foods." + foodInfo[0]);
                int quantity = int.Parse(foodInfo[1]);

                IFood food = (Food)Activator.CreateInstance(foodType, quantity);

                try
                {
                    animals.Last().Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            animals.ForEach(a => Console.WriteLine(a.ToString()));
        }

        private static void CreateMammal(List<Animal> animals, string[] data, string animalType)
        {
            string name = data[1];
            double weight = double.Parse(data[2]);
            string livingRegion = data[3];

            if (animalType == "Dog")
            {
                Animal dog = new Dog(name, weight, livingRegion);
                Console.WriteLine(dog.ProduceSound());
                animals.Add(dog);
            }
            else
            {
                Animal mouse = new Mouse(name, weight, livingRegion);
                Console.WriteLine(mouse.ProduceSound());
                animals.Add(mouse);
            }

        }

        private static void CreateBird(List<Animal> animals, string[] data, string animalType)
        {
            string name = data[1];
            double weight = double.Parse(data[2]);
            double wingSize = double.Parse(data[3]);

            if (animalType == "Hen")
            {
                Animal hen = new Hen(name, weight, wingSize);
                Console.WriteLine(hen.ProduceSound());
                animals.Add(hen);
            }
            else
            {
                Animal owl = new Owl(name, weight, wingSize);
                Console.WriteLine(owl.ProduceSound());
                animals.Add(owl);
            }
        }

        private static void CreateFeline(List<Animal> animals, string[] data, string animalType)
        {
            string name = data[1];
            double weight = double.Parse(data[2]);
            string livingRegion = data[3];
            string breed = data[4];

            if (animalType == "Cat")
            {
                Animal cat = new Cat(name, weight, livingRegion, breed);
                Console.WriteLine(cat.ProduceSound());
                animals.Add(cat);
            }
            else
            {
                Animal tiger = new Tiger(name, weight, livingRegion, breed);
                Console.WriteLine(tiger.ProduceSound());
                animals.Add(tiger);
            }
        }
    }
}