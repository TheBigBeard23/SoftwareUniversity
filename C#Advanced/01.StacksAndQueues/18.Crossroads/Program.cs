using System;
using System.Collections.Generic;

namespace _18.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int durationGreenLight = int.Parse(Console.ReadLine());
            int durationFreeWindow = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int passedCarCount = 0;
            bool crashHappend = false;

            while (input!="END")
            {
                if (input == "green")
                {
                    skipCars(cars, durationGreenLight, durationFreeWindow , ref passedCarCount,ref crashHappend);
                    if (crashHappend)
                    {
                        break;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            if (!crashHappend)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarCount} total cars passed the crossroads.");
            }
        }

        static void skipCars(Queue<string> cars, int durationGreenLight, int durationFreeWindow,ref int passedCarCount,ref bool crash)
        {
            
            while (durationGreenLight > 0 && cars.Count > 0)
            {
                string car = cars.Peek();

                if (car.Length <= durationGreenLight)
                {
                    cars.Dequeue();
                    durationGreenLight -= car.Length;
                    passedCarCount++;
                }
                else if (car.Length <= durationGreenLight + durationFreeWindow)
                {
                    cars.Dequeue();
                    durationGreenLight -= car.Length;
                    passedCarCount++;
                }
                else
                {
                    int index = durationGreenLight + durationFreeWindow;
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{car} was hit at {car.Substring(index, 1)}.");
                    crash = true;
                    break;
                }


            }
        }
    }
}
