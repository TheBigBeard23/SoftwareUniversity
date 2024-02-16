namespace PizzaCalories
{
    public class Topping
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 50;
        private const double defaultCaloriesPerG = 2;

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public string ToppingType
        {
            get => this.toppingType;
            private set
            {
                if (value.ToLower() != "meat"
                    && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese"
                    && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                else
                {
                    this.toppingType = value;
                }
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                else
                {
                    this.weight = value;
                }
            }
        }

        public double Calories => CalculateCalories();

        private double CalculateCalories()
        {
            double typeModifier = 0;

            switch (this.toppingType.ToLower())
            {
                case "meat":
                    typeModifier = 1.2;
                    break;
                case "veggies":
                    typeModifier = 0.8;
                    break;
                case "cheese":
                    typeModifier = 1.1;
                    break;
                default:
                    typeModifier = 0.9;
                    break;
            }

            return defaultCaloriesPerG * typeModifier * this.weight;
        }
    }
}
