using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordTime = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

           
            double finalTime = (distance * timePerMeter) + (int)(distance / 15) * 12.5;

            if (finalTime< recordTime)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {finalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {finalTime- recordTime:f2} seconds slower.");
            }

        }
    }
}
