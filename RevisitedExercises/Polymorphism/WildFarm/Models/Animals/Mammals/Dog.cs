using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double WeightModifier = 0.40;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion, WeightModifier, AllowedFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
