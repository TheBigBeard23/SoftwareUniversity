using System;
using System.Linq;

namespace _16.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            string[] commands = Console.ReadLine().Split();
            int[] startPosition = new int[2];
            int coalsCount = 0;

            for (int row = 0; row < n; row++)
            {
                char[] crnField = Console.ReadLine().Split()
                                                    .Select(char.Parse)
                                                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = crnField[col];

                    if (crnField[col] == 's')
                    {
                        startPosition[0] = row;
                        startPosition[1] = col;
                    }
                    else if (crnField[col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }


            int startRow = startPosition[0];
            int startCol = startPosition[1];

            for (int i = 0; i < commands.Length; i++)
            {
                string direction = commands[i];

                switch (direction)
                {
                    case "up":
                        startRow--;
                        if (!CheckPosition(n, startRow))
                        {
                            startRow++;
                        }
                        break;

                    case "right":
                        startCol++;
                        if (!CheckPosition(n, startCol))
                        {
                            startCol--;
                        }
                        break;

                    case "down":
                        startRow++;
                        if (!CheckPosition(n, startRow))
                        {
                            startRow--;
                        }
                        break;

                    case "left":
                        startCol--;
                        if (!CheckPosition(n, startCol))
                        {
                            startCol++;
                        }
                        break;
                }

                if (matrix[startRow, startCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                    break;
                }
                else if(matrix[startRow, startCol] == 'c')
                {
                    coalsCount--;
                    if (coalsCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                        break;
                    }
                }
                else if (i == commands.Length - 1)
                {
                    Console.WriteLine($"{coalsCount} coals left. ({startRow}, {startCol})");
                    break;
                }

                matrix[startRow, startCol] = '*';

            }
        }

        static bool CheckPosition(int n, int row)
        {
            if (row < 0 || row >= n)
            {
                return false;
            }
            return true;
        }
    }
}
