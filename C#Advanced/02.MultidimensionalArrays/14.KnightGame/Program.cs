using System;

namespace _14.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            bool canAttack = true;
            int[] coordinates = new int[2] {-1,-1};
            int attackCount = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int knightsCount = 0;

            while (canAttack)
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        int crnAttackCount = 0;

                        if (matrix[row, col] == 'K')
                        {
                            crnAttackCount = CheckMoves(matrix, row, col, crnAttackCount);

                            if (crnAttackCount > attackCount)
                            {
                                coordinates[0] = row;
                                coordinates[1] = col;
                                attackCount = crnAttackCount;
                                canAttack = true;
                            }
                        }
                    }
                }

                if (coordinates[0] != -1 && coordinates[1] != -1)
                {
                    knightsCount++;
                    matrix[coordinates[0], coordinates[1]] = '0';
                    coordinates[0] = -1;
                    coordinates[1] = -1;
                    attackCount = 0;
                }
                else
                {
                    canAttack = false;
                }

            }

            Console.WriteLine(knightsCount);
        }

        static int CheckMoves(char[,] matrix, int row, int col, int crnAttackCount)
        {
            int matrixLength = matrix.GetLength(0) - 1;

            if (row - 2 >= 0 && col + 1 <= matrixLength &&
                matrix[row - 2, col + 1] == 'K')
            {
                crnAttackCount++;
            }
            if (row - 2 >= 0 && col - 1 >= 0 &&
                matrix[row - 2, col - 1] == 'K')
            {
                crnAttackCount++;
            }
            if (row + 1 <= matrixLength && col + 2 <= matrixLength &&
                matrix[row + 1, col + 2] == 'K')
            {
                crnAttackCount++;
            }
            if (row - 1 >= 0 && col + 2 <= matrixLength &&
                matrix[row - 1, col + 2] == 'K')
            {
                crnAttackCount++;
            }
            if (row + 2 <= matrixLength && col + 1 <= matrixLength &&
                matrix[row + 2, col + 1] == 'K')
            {
                crnAttackCount++;
            }
            if (row + 2 <= matrixLength && col - 1 >= 0 &&
                matrix[row + 2, col - 1] == 'K')
            {
                crnAttackCount++;
            }
            if (row + 1 <= matrixLength && col - 2 >= 0 &&
                matrix[row + 1, col - 2] == 'K')
            {
                crnAttackCount++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 &&
                matrix[row - 1, col - 2] == 'K')
            {
                crnAttackCount++;
            }

            return crnAttackCount;
        }
    }
}
