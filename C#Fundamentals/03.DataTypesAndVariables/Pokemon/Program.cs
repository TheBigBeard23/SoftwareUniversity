using System;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokemonPower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int halfPower = pokemonPower / 2;
            int targetCount = 0;
            
            while (pokemonPower>=distance)
            {
                pokemonPower -= distance;
                targetCount++;

                if (pokemonPower == halfPower && exhaustionFactor!=0)
                {
                    pokemonPower /= exhaustionFactor;
                }
                
            }

            Console.WriteLine($"{pokemonPower}");
            Console.WriteLine($"{targetCount}");
        }
    }
}
