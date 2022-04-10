using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Queue<string> data = new Queue<string>();

            for (int i = 0; i < count; i++)
            {
                data.Enqueue(Console.ReadLine()+$" {i}");
            }

            int tankAmount = 0;

            for (int i = 0; i < data.Count; i++)
            {
                string[] crnData = data.Dequeue().Split();
                int fuel = int.Parse(crnData[0]);
                int distance = int.Parse(crnData[1]);

                tankAmount += fuel;

                if (tankAmount >= distance)
                {
                    tankAmount -= distance;
                }
                else
                {
                    tankAmount = 0;
                    i = -1;
                }
                data.Enqueue(string.Join(" ", crnData));
            }

            Console.WriteLine(data.Peek().Split().ToArray() [2]);
        }
    }
}
