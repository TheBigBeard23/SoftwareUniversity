using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericMergeSort
{
    public class Mergesort<T> where T : IComparable
    {
        public static IEnumerable<T> MergeSort<T>(IEnumerable<T> list) where T : IComparable
        {
            T[] items = list.ToArray();
            return InternalMergeSort(items);
        }

        private static T[] InternalMergeSort<T>(T[] items) where T : IComparable
        {
            if (items.Length == 1)
            {
                return items;
            }

            int middle = items.Length / 2;

            T[] left = new T[middle];
            T[] right = new T[items.Length - middle];
            Array.Copy(items, left, left.Length);
            Array.Copy(items, middle, right, 0, right.Length);

            left = InternalMergeSort(left);
            right = InternalMergeSort(right);

            return Merge(left, right);
        }

        private static T[] Merge<T>(T[] left, T[] right) where T : IComparable
        {
            T[] sortedArray = new T[left.Length + right.Length];
            int arrayIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) > 0)
                {
                    sortedArray[arrayIndex++] = right[rightIndex++];
                }
                else
                {
                    sortedArray[arrayIndex++] = left[leftIndex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                sortedArray[arrayIndex++] = left[i];
            }
            for (int i = rightIndex; i < right.Length; i++)
            {
                sortedArray[arrayIndex++] = right[i];
            }

            return sortedArray;
        }
    }
}
