using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WeightModifier = 0.10;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit),
        };
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion, WeightModifier, AllowedFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
