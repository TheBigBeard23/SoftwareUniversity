using System;

namespace _09.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);
            string type = Console.ReadLine();

            Predicate<int> checkEvenNumber = x => x % 2 == 0;
            Predicate<int> checkOddNumber = x => x % 2 == 1;
            Action<int,int,Predicate<int>> printerDelegate = Printer;

            switch (type)
            {
                case "odd":
                    printerDelegate(start, end, checkOddNumber);
                    break;

                case "even":
                    printerDelegate(start, end, checkEvenNumber);
                    break;
            }
        }
        static void Printer(int start, int end, Predicate<int> predicate)
        {
            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
