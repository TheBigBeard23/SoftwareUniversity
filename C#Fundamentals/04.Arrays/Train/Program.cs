using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonCount = int.Parse(Console.ReadLine());
            int[] wagonsPassengers = new int[wagonCount];
            int totalPassengers = 0;

            for (int i = 0; i < wagonCount; i++)
            {
                int currentPassengers = int.Parse(Console.ReadLine());
                wagonsPassengers[i] = currentPassengers;
                totalPassengers += currentPassengers;
            }

            foreach (var passenger in wagonsPassengers)
            {
                Console.Write($"{passenger} ");
            }
            Console.WriteLine();
            Console.WriteLine(totalPassengers);
        }
    }
}
