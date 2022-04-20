using System;
using System.Linq;

namespace _09.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = parameters[0];
            int cols = parameters[1];
            string[,] matrix = new string[rows, cols];
            int squaresCount = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] symbols = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                string crnSymbol = string.Empty;

                for (int col = 0; col < cols; col++)
                {
                    crnSymbol = matrix[row, col];

                    if (col + 1 <= cols - 1 &&
                        row + 1 <= rows - 1)
                    {
                        if (matrix[row, col + 1] == crnSymbol &&
                            matrix[row + 1, col] == crnSymbol &&
                            matrix[row + 1, col + 1] == crnSymbol)
                        {
                            squaresCount++;
                        }
                    }
                }
            }

            Console.WriteLine(squaresCount);

        }
    }
}
