using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Feline
{
    public class Tiger : Feline
    {
        private const double WeightModifier = 1.00;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed, WeightModifier, AllowedFoods)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
