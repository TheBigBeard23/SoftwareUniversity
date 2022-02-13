using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                                 .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();
            int sum = 0;

            while (sequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int ithem = sequence[0];
                    sum += ithem;
                    sequence.RemoveAt(0);
                    sequence.Insert(0, sequence[sequence.Count - 1]);
                    IncreasingAndDecresingIthems(sequence, ithem);
                }
                else if (index > sequence.Count - 1)
                {
                    int ithem = sequence[sequence.Count - 1];
                    sum += ithem;
                    sequence.RemoveAt(sequence.Count - 1);
                    sequence.Insert(sequence.Count, sequence[0]);
                    IncreasingAndDecresingIthems(sequence, ithem);
                }
                else
                {
                    int currentIthem = sequence[index];
                    sequence.RemoveAt(index);
                    sum += currentIthem;
                    IncreasingAndDecresingIthems(sequence, currentIthem);
                }
            }

            Console.WriteLine(sum);
        }
        static void IncreasingAndDecresingIthems(List<int> ithems,int value)
        {
            for (int i = 0; i < ithems.Count; i++)
            {
                if (ithems[i] <= value)
                {
                    ithems[i] += value;
                }
                else
                {
                    ithems[i] -= value;
                }
            }
        }
    }
}
