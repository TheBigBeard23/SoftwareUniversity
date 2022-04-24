using System;
using System.Linq;

namespace _15.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];

            for (int row = 0; row < n; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < data.Length; i++)
            {
                int[] coordinates = data[i].Split(",", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];
                int bombPower = matrix[row, col];

                if (bombPower > 0)
                {
                    if (row - 1 >= 0 &&
                        matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bombPower;
                    }

                    if (row - 1 >= 0 && col + 1 < n &&
                        matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= bombPower;
                    }

                    if (col + 1 < n &&
                        matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bombPower;
                    }

                    if (row + 1 < n && col + 1 < n &&
                        matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= bombPower;
                    }

                    if (row + 1 < n &&
                        matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bombPower;
                    }

                    if (row + 1 < n && col - 1 >= 0 &&
                        matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= bombPower;
                    }

                    if (col - 1 >= 0 &&
                        matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bombPower;
                    }

                    if (row - 1 >= 0 && col - 1 >= 0 &&
                        matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= bombPower;
                    }
                }

                matrix[row, col] = 0;
            }

            //int result = Enumerable.Range(0, matrix.First().Length)
            //                       .Sum(column => Enumerable.Range(0, matrix.Length)
            //                       .Select(row => matrix[row][column])
            //                       .Where(value => value > 0)
            //                       .Sum());

            //int cellsCount = Enumerable.Range(0, matrix.First().Length)
            //                       .Sum(column => Enumerable.Range(0, matrix.Length)
            //                       .Select(row => matrix[row][column])
            //                       .Where(value => value > 0)
            //                       .Count());
            int cellsCount = 0;
            int result = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        cellsCount++;
                        result += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {cellsCount}");
            Console.WriteLine($"Sum: {result}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }

    }
}
