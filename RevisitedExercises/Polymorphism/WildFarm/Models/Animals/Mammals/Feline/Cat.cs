using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Feline
{
    public class Cat : Feline
    {
        private const double WeightModifier = 0.30;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
        };
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed, WeightModifier, AllowedFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
