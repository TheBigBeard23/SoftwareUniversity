using System;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTribonacciSequence(n);
        }

        static void PrintTribonacciSequence(int n)
        {
            int n1 = 0;
            int n2 = 1;
            int n3 = 1;
            int n4 = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == 1)
                {
                    Console.Write("1 ");
                }
                else
                {
                    n4 += n3 + n2 + n1;

                    Console.Write($"{n4} ");

                    n1 = n2;
                    n2 = n3;
                    n3 = n4;
                    n4 = 0;
                }

            }
        }
    }
}
