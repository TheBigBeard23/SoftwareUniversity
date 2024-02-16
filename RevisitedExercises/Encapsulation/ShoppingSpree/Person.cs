using System;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    this.money = value;
                }
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag;

        public string Buy(Product product)
        {
            if (this.money >= product.Cost)
            {
                this.money -= product.Cost;
                this.bag.Add(product);

                return $"{this.name} bought {product.Name}";
            }
            else
            {
                return $"{this.name} can't afford {product.Name}";
            }
        }

        public void PrintProducts()
        {
            if(bag.Count > 0)
            {
                Console.WriteLine($"{this.Name} - {string.Join(", ", this.Bag.Select(b => b.Name).ToArray())}");
            }
            else
            {
                Console.WriteLine($"{this.name} - Nothing bought");
            }
        }
    }
}
