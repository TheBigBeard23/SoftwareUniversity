using WildFarm.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double WeightModifier = 0.25;
        private static HashSet<string> AllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize, WeightModifier, AllowedFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
