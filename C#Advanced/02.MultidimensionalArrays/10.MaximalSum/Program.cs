using System;
using System.Linq;

namespace _10.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(int.Parse)
                                                 .ToArray();

            int rows = parameters[0];
            int cols = parameters[1];
            int[,] matrix = new int[rows, cols];
            int sum = int.MinValue;
            int[] coordinates = new int[2];

            for (int row = 0; row < rows; row++)
            {
                int[] symbols = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                int crnSum = 0;

                for (int col = 0; col < cols; col++)
                {
                    if (row + 2 <= rows - 1 &&
                        col + 2 <= cols - 1)
                    {
                        crnSum = matrix[row, col] +
                                 matrix[row, col + 1] +
                                 matrix[row, col + 2] +
                                 matrix[row + 1, col] +
                                 matrix[row + 1, col + 1] +
                                 matrix[row + 1, col + 2] +
                                 matrix[row + 2, col] +
                                 matrix[row + 2, col + 1] +
                                 matrix[row + 2, col + 2];

                        if (sum < crnSum)
                        {
                            sum = crnSum;
                            coordinates[0] = row;
                            coordinates[1] = col;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            int startRow = coordinates[0];
            int startCol = coordinates[1];

            for (int row = startRow; row <= startRow + 2; row++)
            {
                for (int col = startCol; col <= startCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
