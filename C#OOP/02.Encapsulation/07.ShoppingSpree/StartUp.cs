using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();

            string[] peopleData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleData.Length; i++)
            {
                string[] personData = peopleData[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);

                try
                {
                    people.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsData.Length; i++)
            {
                string[] productData = productsData[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = productData[0];
                decimal price = decimal.Parse(productData[1]);

                try
                {
                    products.Add(new Product(name, price));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] crnArgs = input.Split();
                string personName = crnArgs[0];
                string productName = crnArgs[1];

                try
                {
                    people.Where(x => x.Name == personName)
                          .FirstOrDefault()
                          .Buy(products.Where(x => x.Name == productName)
                          .FirstOrDefault());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
