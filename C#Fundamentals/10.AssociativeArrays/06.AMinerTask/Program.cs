using System;
using System.Collections.Generic;

namespace _06.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();

            Dictionary<string, int> resourceQuantity = new Dictionary<string, int>();

            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity[resource] = 0;
                }
                resourceQuantity[resource] += quantity;

                resource = Console.ReadLine();
            }

            foreach (var item in resourceQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
