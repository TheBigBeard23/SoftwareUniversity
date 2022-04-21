using System;
using System.Linq;

namespace _12.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split()
                                                 .Select(int.Parse)
                                                 .ToArray();
            int rows = parameters[0];
            int cols = parameters[1];

            char[,] matrix = new char[rows, cols];

            string word = Console.ReadLine();

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = word[0];
                        word = word.Remove(0, 1);
                        word += matrix[row, col];
                    }
                }

                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = word[0];
                        word = word.Remove(0, 1);
                        word += matrix[row, col];
                    }
                }

            }


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
