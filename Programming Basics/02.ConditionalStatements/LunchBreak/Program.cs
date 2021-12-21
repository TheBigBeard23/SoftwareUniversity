using System;

namespace LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string serialName = Console.ReadLine();
            int epTime = int.Parse(Console.ReadLine());
            int breakTime = int.Parse(Console.ReadLine());

            double timeLeft = 0;
            double timeForLunch = breakTime / 8.0;
            double timeForChill = breakTime / 4.0;

            timeLeft = breakTime - (timeForLunch + timeForChill);

            if (timeLeft >= epTime)
            {
                Console.WriteLine($"You have enough time to watch {serialName} and left with {Math.Ceiling(timeLeft-epTime)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {serialName}, you need {Math.Ceiling(epTime-timeLeft)} more minutes.");
            }
        }
    }
}
