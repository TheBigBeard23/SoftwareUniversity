using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int BaseCaloriesPerGram = 2;
        private const double MinWeight = 1;
        private const double MaxWeight = 50;

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
        public string ToppingType
        {
            get => toppingType;
            private set
            {
                Validator.ThrowIfToppingTypeIsInvalid
                    (value.ToLower(), $"Cannot place {value} on top of your pizza.");
                toppingType = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                Validator.ThrowIfToppinghWeightIsOutOfRange
                    (value, MinWeight, MaxWeight, $"{ToppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");
                weight = value;
            }
        }
        public double Calories => CalculateCalories();

        private double CalculateCalories()
        {
            double typeModifier = 0;
            switch (ToppingType.ToLower())
            {
                case "meat":
                    typeModifier = 1.2;
                    break;
                case "veggies":
                    typeModifier = 0.8;
                    break;
                case "cheese":
                    typeModifier = 1.1;
                    break;
                case "sauce":
                    typeModifier = 0.9;
                    break;
            }
            return weight * BaseCaloriesPerGram * typeModifier;
        }

    }
}
