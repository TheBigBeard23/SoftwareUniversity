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

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Name cannot be empty");

                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                Validator.ThrowIfNumberIsNegative(value, "Money cannot be negative");

                money = value;
            }
        }
        public void Buy(Product product)
        {
            if (money - product.Cost >= 0)
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                money -= product.Cost;
                bag.Add(product);
            }
            else
            {
                Validator.ThrowIfMoneyIsNotEnough(Name, product.Name);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (bag.Count > 0)
            {
                sb.Append($"{Name} - ");
                sb.Append(string.Join(", ", bag));
            }
            else
            {
                sb.Append($"{Name} - Nothing bought");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
