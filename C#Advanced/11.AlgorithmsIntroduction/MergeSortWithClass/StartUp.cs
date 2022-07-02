using System;

namespace GenericMergeSort
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] { 5, 3, 2, 1, 4 };

            var sortedArray = Mergesort<int>.MergeSort(array);

            Console.WriteLine(string.Join(",", sortedArray));
        }
    }
}
