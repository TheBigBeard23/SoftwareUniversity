using System;

namespace _06.QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 2, 9, 10, 1, 1, 4, 6, 5 };
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine(string.Join(" ", array));
        }
        public static int[] QuickSort(int[] array, int begin, int end)
        {
            if (begin < end)
            {
                int pivot = Partition(array, begin, end);

                QuickSort(array, begin, pivot - 1);
                QuickSort(array, pivot + 1, end);
            }
            return array;

        }
        public static int Partition(int[] array, int begin, int end)
        {
            int pivot = array[end];
            int i = begin - 1;
            int item;
            for (int j = begin; j < end; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;

                    item = array[i];
                    array[i] = array[j];
                    array[j] = item;
                }
            }

            item = array[i + 1];
            array[i + 1] = array[end];
            array[end] = item;

            return i + 1;
        }
    }
}
