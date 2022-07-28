using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double BaseWeightModifier = 0.25;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Owl(
            string name,
            double weight,
            double wingSize
            )
            : base(name, weight, AllowedFoods, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
