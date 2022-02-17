using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int daysCount = 0;
            int yieldQuantity = 0;

            if (startingYield < 100)
            {
                Console.WriteLine($"{daysCount}");
                Console.WriteLine($"{yieldQuantity}");
                return;
            }

            while (startingYield>=100)
            {
                daysCount++;
                yieldQuantity += startingYield - 26;
                startingYield -= 10;
            }
            yieldQuantity -= 26;

            Console.WriteLine($"{daysCount}");
            Console.WriteLine($"{yieldQuantity}");
        }
    }
}
