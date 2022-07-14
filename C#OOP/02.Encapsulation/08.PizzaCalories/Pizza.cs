using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinLength = 1;
        private const int MaxLength = 15;
        private const int MinCount = 0;
        private const int MaxCount = 10;

        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfPizzaNameIsInvalid
                    (value, MinLength, MaxLength, $"Pizza name should be between {MinLength} and {MaxLength} symbols.");
                name = value;
            }
        }
        public Dough Dough
        {
            get; private set;
        }
        public int ToppingsCount => toppings.Count;
        public double TotalCalories => GetTotalCalaries();

        public void AddTopping(Topping topping)
        {
            Validator.ThrowIfToppingsCountIsOutOfRange
                (ToppingsCount, MinCount, MaxCount, $"Number of toppings should be in range [{MinCount}..{MaxCount}].");
            toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
        private double GetTotalCalaries()
        {
            double result = 0.0;

            foreach (var topping in toppings)
            {
                result += topping.Calories;
            }

            result += Dough.Calories;

            return result;
        }
    }
}
