using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughData = Console.ReadLine().Split();
            string flourType = doughData[1];
            string bakingTech = doughData[2];
            double doughWeight = double.Parse(doughData[3]);
            try
            {
                Pizza pizza = new Pizza(pizzaName, new Dough(flourType, bakingTech, doughWeight));

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingData = input.Split();
                    string type = toppingData[1];
                    double toppingWeight = double.Parse(toppingData[2]);
                    Topping topping = new Topping(type, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.Write(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
