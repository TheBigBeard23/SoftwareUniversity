using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split()
                .ToArray();

            
            int arrayLength = 0;
            string element = string.Empty;
            
            for (int i = 0; i < elements.Length; i++)
            {
                int lengthCounter = 1;

                for (int j = i+1; j < elements.Length; j++)
                {
                    if (elements[i] == elements[j])
                    {
                        lengthCounter++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (lengthCounter > arrayLength)
                {
                    arrayLength = lengthCounter;
                    element = elements[i];
                }

            }

            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write($"{element} ");
            }
           
        }
    }
}
