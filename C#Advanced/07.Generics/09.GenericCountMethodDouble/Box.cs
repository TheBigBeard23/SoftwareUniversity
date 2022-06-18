using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box
    {
        public static int Compare<T>(List<T> list, T value)
        {
            int count = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (Comparer<T>.Default.Compare(list[i], value) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
