using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = parameters[0];
            int cols = parameters[1];

            int[,] matrix = new int[rows, cols];
            int sum = 0;
            int[] numbers = new int[4];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(", ")
                                                .Select(int.Parse)
                                                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                
                for (int col = 0; col < cols; col++)
                {
                    if (row + 1 < rows &&
                        col + 1 < cols)
                    {
                        int crnSum = matrix[row, col] + matrix[row, col + 1] + matrix[row+1, col] + matrix[row+1, col + 1];

                        if (sum < crnSum)
                        {
                            sum = crnSum;
                            numbers[0] = matrix[row, col];
                            numbers[1] = matrix[row, col + 1];
                            numbers[2] = matrix[row + 1, col];
                            numbers[3] = matrix[row + 1, col + 1];
                        }
                    }
                }
            }

            Console.WriteLine($"{numbers[0]} {numbers[1]}");
            Console.WriteLine($"{numbers[2]} {numbers[3]}");
            Console.WriteLine(sum);
        }
    }
}
