using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WeightModifier = 0.35;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds),
        };
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize, WeightModifier, AllowedFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
