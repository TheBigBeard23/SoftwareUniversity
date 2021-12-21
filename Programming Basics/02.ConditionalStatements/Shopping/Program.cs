using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpuCount = int.Parse(Console.ReadLine());
            int cpuCount = int.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            double gpuPrice = gpuCount * 250;
            double cpuPrice = (gpuPrice * 0.35) * cpuCount;
            double ramPrice = (gpuPrice * 0.10) * ramCount;

            totalPrice = gpuPrice + cpuPrice + ramPrice;
            if (gpuCount > cpuCount)
            {
                totalPrice -= totalPrice * 0.15;
            }


            if (budget > totalPrice )
            {
                Console.WriteLine($"You have {budget-totalPrice} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice-budget} leva more!");
            }

        }
    }
}
