namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine()
                .Split()[1];

            string[] doughData = Console.ReadLine()
                .Split();

            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            double weigth = double.Parse(doughData[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weigth);
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingsInput;

                while ((toppingsInput = Console.ReadLine()) != "END")
                {
                    string[] data = toppingsInput.Split();
                    string toppingName = data[1];
                    double toppingWeigth = double.Parse(data[2]);

                    pizza.AddTopping(new Topping(toppingName, toppingWeigth));
                }

                Console.WriteLine($"{pizzaName} - {pizza.Calories:f2} Calories.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}