using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split()
                                                 .Select(int.Parse)
                                                 .ToArray();

            int n = parameters[0];
            int s = parameters[1];
            int x = parameters[2];




            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split()
                                                                  .Select(int.Parse)
                                                                  .Take(n));

            for (int i = 0; i < s; i++)
            {
                numbers.Dequeue();

                if (numbers.Count == 0)
                {
                    Console.WriteLine("0");
                    break;
                }

            }

            if (numbers.Count > 0)
            {
                int minNumber = int.MaxValue;
                bool isPresent = false;

                while (numbers.Count > 0)
                {
                    int crnNumber = numbers.Dequeue();

                    if (minNumber > crnNumber)
                    {
                        minNumber = crnNumber;
                    }

                    if (crnNumber == x)
                    {
                        Console.WriteLine("true");
                        isPresent = true;
                        break;
                    }

                }

                if (!isPresent)
                {
                    Console.WriteLine(minNumber);
                }
            }
        }
    }
}
