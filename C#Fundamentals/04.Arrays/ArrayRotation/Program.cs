using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split()
                .ToArray();

            int rotationIndex = int.Parse(Console.ReadLine());
            int arrayLength = array.Length;

            if (rotationIndex > arrayLength)
            {
                rotationIndex = rotationIndex - arrayLength;
            }
            
            for (int i = 0; i < rotationIndex; i++)
            {
                string currentElement = array[0];

                for (int k = 0; k < array.Length-1; k++)
                {
                    array[k] = array[k+1];
                }

                array[arrayLength - 1] = currentElement;
            }

            Console.WriteLine(string.Join(" ",array));
        }
    }
}
