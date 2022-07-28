using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1.00;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Tiger(
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
            return "ROAR!!!";
        }
    }
}
