using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int count = int.Parse(Console.ReadLine());
            int passedCars = 0;
            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    PrintPassedCars(cars, count, ref passedCars);
                  
                }

                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }

        static void PrintPassedCars(Queue<string> cars, int count,ref int passedCars)
        {
            for (int i = 0; i < count; i++)
            {
                if (cars.Count == 0)
                {
                    break;
                }

                Console.WriteLine($"{cars.Dequeue()} passed!");
                passedCars++;
            }
        }
    }
}
