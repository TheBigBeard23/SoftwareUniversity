using System;
using System.Collections.Generic;

namespace _11.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            while (n>0)
            {
                string[] data = Console.ReadLine().Split();

                string command = data[0];

                switch (command)
                {
                    case "1":
                        int number = int.Parse(data[1]);
                        numbers.Push(number);
                        break;

                    case "2":
                        if (numbers.Count > 0)
                        {
                            numbers.Pop();
                        }
                        break;

                    case "3":
                        if (numbers.Count > 0)
                        {
                            PrintMaxNumber(numbers);
                        }
                        break;

                    case "4":
                        if (numbers.Count > 0)
                        {
                            PrintMinNumber(numbers);
                        }
                        break;

                }
                n--;
            }

            Console.WriteLine(string.Join(", ",numbers));
        }

        private static void PrintMaxNumber(Stack<int> numbers)
        {
            int[] elements = numbers.ToArray();

            int maxNum = int.MinValue;
            
            for (int i = 0; i < elements.Length; i++)
            {
                int crnNumber = elements[i];

                if (crnNumber > maxNum)
                {
                    maxNum = crnNumber;
                }

            }

            Console.WriteLine(maxNum);
        }

        private static void PrintMinNumber(Stack<int> numbers)
        {
            int[] elements = numbers.ToArray();

            int minNum = int.MaxValue;

            for (int i = 0; i < elements.Length; i++)
            {
                int crnNumber = elements[i];

                if (crnNumber < minNum)
                {
                    minNum = crnNumber;
                }

            }

            Console.WriteLine(minNum);
        }
    }
}
