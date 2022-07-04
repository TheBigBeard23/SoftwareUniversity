using System;
using System.Collections.Generic;
using System.Text;

namespace _07.BinarySearch
{
    public class BinarySearch
    {
        public static int IndexOf(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;
            int mid;

            while (low <= high)
            {

                mid = (low + high) / 2;

                if (array[mid] < value)
                {
                    low = mid + 1;
                }
                else if (array[mid] > value)
                {
                    high = mid - 1;
                }
                else
                {
                    Console.WriteLine("The value is at index:");
                    return mid;
                }
            }
            Console.WriteLine("The value does not exist");
            return -1;
        }
    }
}
