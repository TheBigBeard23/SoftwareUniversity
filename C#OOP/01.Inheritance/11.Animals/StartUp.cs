using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    var animalData = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string name = animalData[0];
                    int age = int.Parse(animalData[1]);
                    string gender = animalData[2];

                    switch (input)
                    {
                        case "Dog":
                            var dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;

                        case "Cat":
                            var cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;

                        case "Frog":
                            var frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;

                        case "Kitten":
                            var kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;

                        case "Tomcat":
                            var tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i]);
            }
        }
    }
}
