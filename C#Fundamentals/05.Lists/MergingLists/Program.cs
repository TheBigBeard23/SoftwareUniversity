using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            List<int> secondList = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .Reverse()
               .ToList();

            List<int> thirdList = MerginLists(firstList, secondList);

            Console.WriteLine(string.Join(" ",thirdList));
        }

        static List<int> MerginLists(List<int> first, List<int> second)
        {
            List<int> newList = new List<int>();

            int count = first.Count + second.Count;

            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0      &&
                    first.Count > 0 ||
                    second.Count == 0)
                {
                    newList.Add(first[first.Count - 1]);
                    first.RemoveAt(first.Count - 1);
                }
                else if (second.Count > 0)
                {
                    newList.Add(second[second.Count - 1]);
                    second.RemoveAt(second.Count - 1);
                }
    
            }

            return newList;

        }
    }
}
