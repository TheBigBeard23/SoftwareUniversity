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

            Dictionary<int, int> drumsQuality = Console.ReadLine()
                                               .Split()
                                               .Select(int.Parse)
                                               .ToDictionary(x => x);

            string input = Console.ReadLine();

            while (input != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                List<int> keys = new List<int>(drumsQuality.Keys);

                foreach (var key in keys)
                {
                    if (drumsQuality[key] != 0)
                    {
                        drumsQuality[key] -= hitPower;

                        if (drumsQuality[key] <= 0)
                        {
                            int priceOfNewDrum = key * 3;

                            if (savings >= priceOfNewDrum)
                            {
                                savings -= priceOfNewDrum;
                                drumsQuality[key] = key;
                            }
                            else
                            {
                                drumsQuality[key] = 0;
                            }
                        }
                    }            
                }

                input = Console.ReadLine();
            }

                List<int> quality = drumsQuality
                            .Values
                            .Where(x => x != 0)
                            .ToList();

                Console.WriteLine(string.Join(" ", quality));
                Console.WriteLine($"Gabsy has {savings:f2}lv.");
            
        }
    }
}

