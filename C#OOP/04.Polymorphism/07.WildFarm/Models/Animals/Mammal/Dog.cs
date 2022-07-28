using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammal
{
    public class Dog : Mammal
    {
        private const double BaseWeightModifier = 0.40;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Dog(
            string name,
            double weight,
            string livingRegion
            )
            : base(name, weight, AllowedFoods, BaseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
