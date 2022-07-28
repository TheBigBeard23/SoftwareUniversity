using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Mammal.Feline
{
    public abstract class Feline : Mammal
    {
        protected Feline(
            string name,
            double weight,
            HashSet<string> allowedFoods,
            double weightModifier,
            string livingRegion,
            string breed
            )
            : base(
                  name,
                  weight,
                  allowedFoods,
                  weightModifier,
                  livingRegion)
        {
            Breed = breed;
        }
        public string Breed { get; private set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
