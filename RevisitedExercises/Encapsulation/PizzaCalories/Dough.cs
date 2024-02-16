namespace PizzaCalories
{
    public class Dough
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        private const double defaultCaloriesPerG = 2;

        private string flourType;
        private string bakingTehnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                else
                {
                    this.flourType = value;
                }
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTehnique;
            private set
            {
                if (value.ToLower() != "crispy"
                    && value.ToLower() != "chewy"
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid baking tehnique.");
                }
                else
                {
                    this.bakingTehnique = value;
                }
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
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

            switch (flourType.ToLower())
            {
                case "white":
                    typeModifier = 1.5;
                    break;
                default:
                    typeModifier = 1.0;
                    break;
            }

            double tehniqueModifier = 0;

            switch (bakingTehnique.ToLower())
            {
                case "crispy":
                    tehniqueModifier = 0.9;
                    break;
                case "chewy":
                    tehniqueModifier = 1.1;
                    break;
                default:
                    tehniqueModifier = 1;
                    break;
            }

            return this.weight * defaultCaloriesPerG * typeModifier * tehniqueModifier;
        }
    }
}
