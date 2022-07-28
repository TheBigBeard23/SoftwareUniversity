using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {

        public Animal(
            string name,
            double weight,
            HashSet<string> allowedFoods,
            double weightModifier
            )
        {
            Name = name;
            Weight = weight;
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }
        private HashSet<string> AllowedFoods { get; set; }
        private double WeightModifier { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract string ProduceSound();
        public void Eat(IFood food)
        {
            string foodType = food.GetType().Name;

            if (!AllowedFoods.Contains(foodType))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodType}!");
            }

            FoodEaten += food.Quantity;

            Weight += food.Quantity * WeightModifier;
        }
    }
}
