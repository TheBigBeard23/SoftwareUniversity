using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int counter = 0;

            while (peopleCount>0)
            {
                counter++;
                peopleCount -= capacity;
            }

            Console.WriteLine(counter);
        }
    }
}
