using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double BaseWeightModifier = 0.30;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable)
        };
        public Cat(
            string name,
            double weight,
            string livingRegion,
            string breed
            )
            : base(
                  name,
                  weight,
                  AllowedFoods,
                  BaseWeightModifier,
                  livingRegion,
                  breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
