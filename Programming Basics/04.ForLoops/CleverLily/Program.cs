using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearsOld = int.Parse(Console.ReadLine());
            double wMPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            
            double savings = 0.0;
            int toysCount = 0;
            int evenBdCount = 1;

            for (int i = 1; i <= yearsOld; i++)
            {
                if (i % 2 == 1)
                {
                    toysCount++;
                }
                else
                {
                    savings += 10 * evenBdCount - 1;
                    evenBdCount++;
                }
            }
            savings += toysCount * toyPrice;
            if (savings >= wMPrice)
            {
                Console.WriteLine($"Yes! {savings-wMPrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(savings-wMPrice):f2}");
            }



        }
    }
}
