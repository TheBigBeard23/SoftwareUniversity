using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToList();

            List<int> secondList = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .Reverse()
                                  .ToList();

            List<int> result = new List<int>();

            int firstNumber = 0;
            int secondNumber = 0;

            if (firstList.Count > secondList.Count)
            {
                MixLists(firstList, secondList, result);
                firstNumber = firstList[firstList.Count - 1];
                secondNumber = firstList[firstList.Count - 2];
            }
            else
            {
                MixLists(secondList, firstList, result);
                firstNumber = secondList[secondList.Count - 1];
                secondNumber = secondList[secondList.Count - 2];
            }

            Console.WriteLine(string.Join(" ", FilterNumbers(result, firstNumber, secondNumber)));
        }

        static List<int> FilterNumbers(List<int> result, int firstNumber, int secondNumber)
        {
            int start = 0;
            int end = 0;

            if (firstNumber > secondNumber)
            {
                start = secondNumber;
                end = firstNumber;
            }
            else
            {
                start = firstNumber;
                end = secondNumber;
            }

            return result
                         .Where
                         (
                             x => x > start &&
                             x < end
                         )
                         .OrderBy(x => x)
                         .ToList();
        }                
        static void MixLists(List<int> firstList, List<int> secondList, List<int> result)
        {
            for (int i = 0; i < secondList.Count; i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[i]);
            }
        }

    }
}
