using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double BaseWeightModifier = 0.35;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds)
        };
        public Hen(
            string name,
            double weight,
            double wingSize
            )
            : base(name, weight, AllowedFoods, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
