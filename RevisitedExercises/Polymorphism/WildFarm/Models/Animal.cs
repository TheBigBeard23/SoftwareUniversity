using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        private HashSet<string> AllowedFoods;
        private double weightModifier;

        public Animal(
            string name,
            double weight,
            double weightModifier,
           HashSet<string> allowedFoods)
        {
            this.Name = name;
            this.Weight = weight;
            this.weightModifier = weightModifier;
            this.AllowedFoods = allowedFoods;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();
        public void Eat(IFood food)
        {
            string typeFood = food.GetType().Name;

            if (this.AllowedFoods.Contains(typeFood))
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * this.weightModifier;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
