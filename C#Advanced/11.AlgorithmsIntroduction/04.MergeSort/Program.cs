using System;
using System.Collections;
using System.Collections.Generic;

namespace _04.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random rand = new Random();

            for (int i = 1; i <= 50; i++)
            {
                list.Add(rand.Next(1, 50));
            }
            Console.WriteLine("Before Sort");
            Console.WriteLine(string.Join(", ", list));

            list = MergeSort(list);
            Console.WriteLine("After Merge Sort");
            Console.WriteLine(string.Join(", ", list));
        }
        static List<int> MergeSort(List<int> list)
        {
            if (list.Count == 1)
            {
                return list;
            }

            int middle = list.Count / 2;

            List<int> leftPart = MergeSort(list.GetRange(0, middle));
            List<int> rightPart = MergeSort(list.GetRange(middle, list.Count - middle));

            return CombineArrays(leftPart, rightPart);
        }

        private static List<int> CombineArrays(List<int> left, List<int> right)
        {
            List<int> sortedList = new List<int>();

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] > right[rightIndex])
                {
                    sortedList.Add(right[rightIndex]);
                    rightIndex++;
                }
                else
                {
                    sortedList.Add(left[leftIndex]);
                    leftIndex++;
                }
            }

            for (int i = leftIndex; i < left.Count; i++)
            {
                sortedList.Add(left[i]);
            }
            for (int i = rightIndex; i < right.Count; i++)
            {
                sortedList.Add(right[i]);
            }

            return sortedList;
        }
    }
}
