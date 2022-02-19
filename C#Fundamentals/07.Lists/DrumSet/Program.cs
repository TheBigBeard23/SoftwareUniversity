using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> initialQuality = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            List<int> currentQuality = new List<int>(initialQuality.Count);

            currentQuality = initialQuality.ToList();

            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!")
            {
                int currentHitPower = int.Parse(command);

                for (int i = 0; i <= currentQuality.Count - 1; i++)
                {
                    currentQuality[i] -= currentHitPower;

                    if (currentQuality[i] <= 0)
                    {
                        double newDrumPrice = initialQuality[i] * 3;

                        if (savings - newDrumPrice < 0)
                        {
                            currentQuality.RemoveAt(i);
                            initialQuality.RemoveAt(i);

                            i--;
                        }
                        else
                        {
                            savings -= newDrumPrice;
                            currentQuality[i] = initialQuality[i];

                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", currentQuality));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");

        }
    }
}

