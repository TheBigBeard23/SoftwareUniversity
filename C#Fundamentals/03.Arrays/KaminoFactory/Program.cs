using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());
            string input = string.Empty;

            int bestSequenceIndex = int.MaxValue;
            int bestSequenceSum = 0;
            int bestSequenceLength = 0;
            int bestRow = 0;
            string bestDna = string.Empty;
            int currentRow = 0;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] dna = input
                    .Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                currentRow++;
                int currentSequenceLength = 0;
                int currentSum = 0;
                int currentIndex = 0;

                for (int i = 0; i < dnaLength; i++)
                {
                    currentSum += dna[i];

                    if (dna[i] == 1)
                    {
                        int sequenceLength = 1;

                        for (int k = i + 1; k < dnaLength; k++)
                        {
                            if (dna[i] == dna[k])
                            {
                                sequenceLength++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (sequenceLength > currentSequenceLength)
                        {
                            currentSequenceLength = sequenceLength;
                            currentIndex = i + 1;
                        }
                    }
                }

                if (currentSequenceLength > bestSequenceLength)
                {
                    bestSequenceIndex = currentIndex;
                    bestSequenceSum = currentSum;
                    bestSequenceLength = currentSequenceLength;
                    bestDna = string.Join(" ", dna);
                    bestRow = currentRow;

                }

                else if (currentSequenceLength == bestSequenceLength &&
                         currentIndex < bestSequenceIndex)
                {
                    bestSequenceIndex = currentIndex;
                    bestSequenceSum = currentSum;
                    bestSequenceLength = currentSequenceLength;
                    bestDna = string.Join(" ", dna);
                }

                else if (currentSequenceLength == bestSequenceLength &&
                         currentIndex == bestSequenceIndex &&
                         currentSum > bestSequenceSum)
                {
                    bestSequenceIndex = currentIndex;
                    bestSequenceSum = currentSum;
                    bestSequenceLength = currentSequenceLength;
                    bestDna = string.Join(" ", dna);
                }

            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(bestDna);

        }


    }
}
