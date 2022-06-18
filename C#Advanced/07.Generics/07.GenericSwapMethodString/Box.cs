using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodString
{
    public class Box
    {
        public static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T firstElement = list[firstIndex];

            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstElement;
        }
    }
}
