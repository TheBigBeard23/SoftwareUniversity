using System;
using System.Linq;

namespace _11.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(int.Parse)
                                                 .ToArray();

            int rows = parameters[0];
            int cols = parameters[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                  .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {

                if (!input.Contains("swap")  ||
                    !input.Any(char.IsDigit) ||
                     input.Split().Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }

                else
                {
                    input = input.Remove(0, 5);

                    int[] coordinates = input.Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray();

                    int xRow = coordinates[0];
                    int xCol = coordinates[1];
                    int yRow = coordinates[2];
                    int yCol = coordinates[3];

                    if (xRow >= 0 && xCol >= 0 &&
                        yRow >= 0 && xCol >= 0 &&
                        xRow < rows && xCol < cols &&
                        yRow < rows && yCol < cols)
                    {
                        string firstElement = matrix[xRow, xCol];
                        matrix[xRow, xCol] = matrix[yRow, yCol];
                        matrix[yRow, yCol] = firstElement;

                        PrintMatrix(rows, cols, matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                input = Console.ReadLine();
            }

        }

        static void PrintMatrix(int rows, int cols, string[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
