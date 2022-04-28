using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = parameters[0];
            int cols = parameters[1];
            char[,] matrix = new char[rows, cols];
            int[] playerCoordinates = new int[2];
            bool isWinning = false;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'P')
                    {
                        playerCoordinates[0] = row;
                        playerCoordinates[1] = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            int pRow = playerCoordinates[0];
            int pCol = playerCoordinates[1];

            for (int i = 0; i < commands.Length; i++)
            {

                if (matrix[pRow, pCol] != 'P')
                {
                    break;
                }

                matrix[pRow, pCol] = '.';
                char command = commands[i];

                switch (command)
                {
                    case 'U':
                        pRow--;
                        break;
                    case 'R':
                        pCol++;
                        break;
                    case 'D':
                        pRow++;
                        break;
                    case 'L':
                        pCol--;
                        break;
                }

                if (pCol < 0 || pCol >= cols ||
                    pRow < 0 || pRow >= rows)
                {
                    isWinning = true;

                    if (pRow == rows)
                    {
                        pRow--;
                    }
                    if (pRow < 0)
                    {
                        pRow++;
                    }
                    if (pCol == cols)
                    {
                        pCol--;
                    }
                    if (pCol < 0)
                    {
                        pCol++;
                    }
                    MoveBunnies(rows, cols, matrix);
                    break;
                }

                else if (matrix[pRow, pCol] == 'B')
                {
                    MoveBunnies(rows, cols, matrix);
                    break;
                }

                matrix[pRow, pCol] = 'P';

                MoveBunnies(rows, cols, matrix);
            }

            if (isWinning)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"win: {pRow} {pCol}");
            }
            else
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {pRow} {pCol}");
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveBunnies(int rows, int cols, char[,] matrix)
        {
            List<List<int>> bunnyPositions = new List<List<int>>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {

                        bunnyPositions.Add(new List<int>() { row, col });
                    }
                }
            }

            for (int i = 0; i < bunnyPositions.Count; i++)
            {
                int row = bunnyPositions[i][0];
                int col = bunnyPositions[i][1];

                if (row - 1 >= 0)
                {
                    matrix[row - 1, col] = 'B';
                }
                if (col + 1 < cols)
                {
                    matrix[row, col + 1] = 'B';
                }
                if (row + 1 < rows)
                {
                    matrix[row + 1, col] = 'B';
                }
                if (col - 1 >= 0)
                {
                    matrix[row, col - 1] = 'B';
                }
            }

        }
    }
}
