using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            string input = Console.ReadLine();

            while (input!="END")
            {
                string[] data = input.Split();
                string command = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int number = int.Parse(data[3]);

                switch (command)
                {
                    case "Add":
                        if (CheckCordinates(row, col, n))
                        {
                            matrix[row, col] += number;
                        }
                        break;

                    case "Subtract":
                        if (CheckCordinates(row, col, n))
                        {
                            matrix[row, col] -= number;
                        }
                        break;

                }
                input = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }

        static bool CheckCordinates(int row, int col, int n)
        {
            if (row < 0 ||
                col < 0 ||
                row > n ||
                col > n)
            {
                Console.WriteLine("Invalid coordinates");
                return false;
            }

            return true;
        }
    }
}
