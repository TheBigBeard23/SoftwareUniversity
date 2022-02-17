using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int a = 0; a < n; a++)
            {

                for (int b = 0; b < n; b++)
                {

                    for (int c = 0; c < n; c++)
                    {
                        Console.Write((char)('a' + a));
                        Console.Write((char)('a' + b));
                        Console.Write((char)('a' + c));
                        Console.WriteLine();
                    }
                }

            }
        }
    }
}
