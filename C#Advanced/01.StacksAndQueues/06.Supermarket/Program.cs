using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string input = Console.ReadLine();

            while (input!="End")
            {
                if (input == "Paid")
                {
                    Pay(customers);
                }

                else
                {
                    customers.Enqueue(input);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }

        static void Pay(Queue<string> customers)
        {
            while (customers.Count>0)
            {
                Console.WriteLine(customers.Dequeue());
            }
        }
    }
}
