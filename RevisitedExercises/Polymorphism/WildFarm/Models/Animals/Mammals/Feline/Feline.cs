namespace WildFarm.Models.Animals.Mammals.Feline
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed, double weightModifier, HashSet<string> allowedFoods)
            : base(name, weight, livingRegion, weightModifier, allowedFoods)
        {
            this.Breed = breed;
        }
        public string Breed { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
