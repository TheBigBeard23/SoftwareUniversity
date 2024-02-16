using System;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] productsData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (string person in peopleData)
            {
                string[] personInfo = person.Split("=", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    people.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            foreach (string product in productsData)
            {
                string[] productInfo = product.Split("=", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string name = productInfo[0];
                    decimal price = decimal.Parse(productInfo[1]);

                    products.Add(new Product(name, price));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split();

                string personName = data[0];
                string productName = data[1];

                Person person = people.Where(p => p.Name == personName).FirstOrDefault();
                Product product = products.Where(p => p.Name == productName).FirstOrDefault();

                try
                {
                    Console.WriteLine(person.Buy(product));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            people.ForEach(p => p.PrintProducts());
        }
    }
}