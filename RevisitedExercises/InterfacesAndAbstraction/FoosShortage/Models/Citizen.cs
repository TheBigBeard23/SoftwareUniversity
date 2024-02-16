namespace FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        private int defaultFood = 0;
        private int foodIncreases = 10;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = defaultFood;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += foodIncreases;
        }
    }
}
