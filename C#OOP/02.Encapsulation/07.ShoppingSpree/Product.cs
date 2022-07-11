using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
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
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                price = value;
            }
        }
    }
}
