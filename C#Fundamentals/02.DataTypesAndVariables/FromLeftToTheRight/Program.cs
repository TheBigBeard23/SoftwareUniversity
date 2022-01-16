using System;
using System.Linq;
using System.Numerics;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
              
                BigInteger biggestNumber = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .Select(x => BigInteger.Parse(x))
                             .OrderByDescending(x => x)
                             .FirstOrDefault();

                int digitsSum = 0;
                string numberAsString = biggestNumber.ToString();

                for (int k = 0; k < numberAsString.Length; k++)
                {
                    digitsSum += int.Parse(numberAsString[k].ToString());
                }

                Console.WriteLine(Math.Abs(digitsSum));
            }
        }
    }
}
