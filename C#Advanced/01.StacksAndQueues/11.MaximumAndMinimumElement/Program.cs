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
                        numbers.Pop();
                        break;

                    case "3":
                        PrintMaxNumber(numbers);
                        break;

                    case "4":
                        PrintMinNumber(numbers);
                        break;

                }

                n--;
            }

            Console.WriteLine(string.Join(", ",numbers));
        }

        private static void PrintMaxNumber(Stack<int> numbers)
        {
            int maxNum = int.MinValue;

            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers.Pop();

                if (number > maxNum)
                {
                    maxNum = number;
                }

                numbers.Push(number);
            }

            Console.WriteLine(maxNum);
        }

        private static void PrintMinNumber(Stack<int> numbers)
        {
            int minNum = int.MaxValue;

            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers.Pop();

                if (number < minNum)
                {
                    minNum = number;
                }

                numbers.Push(number);
            }

            Console.WriteLine(minNum);
        }
    }
}
