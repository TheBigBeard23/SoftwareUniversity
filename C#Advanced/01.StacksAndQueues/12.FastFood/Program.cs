using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split()
                                                                 .Select(int.Parse));
            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                int crnOrder = orders.Peek();

                if (foodQuantity - crnOrder >= 0)
                {
                    foodQuantity -= crnOrder;
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
