using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToList();

            List<int> data = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToList();

            int bomb = data[0];
            int power = data[1];

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] == bomb)
                {
                    sequence[i] = 0;

                    for (int k = i + 1; k <= i + power; k++)
                    {
                        if (k >= sequence.Count)
                        {
                            break;
                        }

                        sequence[k] = 0;
                    }

                    for (int k = i - 1; k >= i - power; k--)
                    {
                        if (k < 0)
                        {
                            break;
                        }

                        sequence[k] = 0;
                    }         

                }
            }

            Console.WriteLine(sequence.Sum());
        }   
    }
}
