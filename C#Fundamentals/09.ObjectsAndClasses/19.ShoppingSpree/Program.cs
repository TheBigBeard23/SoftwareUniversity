using System;
using System.Collections.Generic;
using System.Linq;

namespace _19.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personsData = Console.ReadLine()
                                      .Split(';')
                                      .ToArray();

            List<Person> persons = new List<Person>();

            for (int i = 0; i < personsData.Length; i++)
            {
                string[] currentPerson = personsData[i].Split('=')
                                                       .ToArray();
                string name = currentPerson[0];
                decimal money = decimal.Parse(currentPerson[1]);
                persons.Add(new Person(name, money));
            }

            string[] productsData = Console.ReadLine()
                                      .Split(';', StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

            List<Product> products = new List<Product>();

            for (int i = 0; i < productsData.Length; i++)
            {
                string[] currentProduct = productsData[i].Split('=')
                                                         .ToArray();
                string name = currentProduct[0];
                decimal price = decimal.Parse(currentProduct[1]);
                products.Add(new Product(name, price));
            }
            ;
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split()
                                     .ToArray();

                string personName = data[0];
                string productName = data[1];

                Person person = persons.Where(x => x.Name == personName).FirstOrDefault();
                Product product = products.Where(x => x.Name == productName).FirstOrDefault();

                if (person.Money >= product.Price)
                {
                    person.Bag.Add(product);
                    person.Money -= product.Price;
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }

                input = Console.ReadLine();

            }

            foreach (var person in persons)
            {
                Console.Write($"{person.Name} - ");

                if (person.Bag.Count == 0)
                {
                    Console.Write("Nothing bought");
                }
                else
                {
                    Console.Write(String.Join(", ", person.Bag.Select(x => x.Name).ToList()));
                }

                Console.WriteLine();

            }
            
        }
    }
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name,decimal price)
        {
            Name = name;
            Price = price;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<Product> Bag { get; set; }

        public Person(string name,decimal money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }
    }
}
