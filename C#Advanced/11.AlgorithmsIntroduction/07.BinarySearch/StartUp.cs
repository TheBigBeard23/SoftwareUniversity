using System;

namespace _07.BinarySearch
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(BinarySearch.IndexOf(array, 9));
            Console.WriteLine(BinarySearch.IndexOf(array, 11));
        }
    }
}
