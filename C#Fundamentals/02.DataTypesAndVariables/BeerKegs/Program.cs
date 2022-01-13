using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, double> kegs = new Dictionary<string, double>();

            for (int i = 0; i < count; i++)
            {
                string model = Console.ReadLine();
                double radious = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radious, 2) * height;

                kegs[model] = volume;
            }

            var biggestKeg = kegs.OrderByDescending(x => x.Value).FirstOrDefault();

            Console.WriteLine(biggestKeg.Key);
        }
    }
}
