using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(", ")
                                                .Select(int.Parse)
                                                .ToArray();
            int rows = matrixData[0];
            int cols = matrixData[1];
            int[,] matrix = new int[rows, cols];
            int[] columns = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split()
                                                  .Select(int.Parse)
                                                  .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                    columns[col] += numbers[col];
                }
            }

            for (int i = 0; i < columns.Length; i++)
            {
                Console.WriteLine(columns[i]);
            }



        }
    }
}
