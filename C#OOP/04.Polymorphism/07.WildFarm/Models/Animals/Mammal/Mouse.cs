using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammal
{
    public class Mouse : Mammal
    {
        private const double BaseWeightModifier = 0.10;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit)
        };
        public Mouse(
            string name,
            double weight,
            string livingRegion
            )
            : base(name, weight, AllowedFoods, BaseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
