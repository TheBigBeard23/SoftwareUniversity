namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinLength = 1;
        private const int MaxLength = 15;
        private const int MinToppingsCount = 0;
        private const int MaxToppingsCount = 10;

        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pizza name should't be an empty string");
                }
                else if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException($"Pizza name should be between {MinLength} and {MaxLength} symbols.");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public Dough Dough { get; set; }
        public IReadOnlyCollection<Topping> Toppings => this.toppings;
        public double Calories => CalculateCalories();

        private double CalculateCalories()
        {
            double calories = 0;

            calories += this.Dough.Calories;

            foreach (var topping in toppings)
            {
                calories += topping.Calories;
            }

            return calories;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MinToppingsCount}..{MaxToppingsCount}].");
            }
            else
            {
                toppings.Add(topping);
            }
        }

    }
}
