namespace WildFarm.Models.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion, double weightModifier, HashSet<string> allowedFoods)
            : base(name, weight, weightModifier, allowedFoods)
        {
            this.LivingRegion = livingRegion;
        }
        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
