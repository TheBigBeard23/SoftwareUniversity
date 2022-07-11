using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name,decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (value == "" || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public void Buy(Product product)
        {
            if (money - product.Price >= 0)
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                money -= product.Price;
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (bag.Count > 0)
            {
                sb.Append($"{Name} -");

                foreach (var product in bag)
                {
                    sb.Append($", {product.Name}");
                }
            }
            else
            {
                sb.Append($"{Name} - Nothing bought");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
