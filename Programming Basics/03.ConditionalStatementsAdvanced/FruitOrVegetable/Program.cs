using System;
using System.Collections.Generic;

namespace FruitOrVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fruits = new List<string>() { "banana", "apple", "kiwi", "cherry", "lemon", "grapes" };
            List<string> vegetable = new List<string>() { "tomato", "cucumber", "pepper", "carrot" };
            string input = Console.ReadLine();

            if (fruits.Contains(input))
            {
                Console.WriteLine("fruit");
            }
            else if (vegetable.Contains(input))
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }

        }
    }
}
