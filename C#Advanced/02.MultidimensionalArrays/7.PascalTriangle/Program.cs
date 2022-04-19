using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                Console.WriteLine(n);
                return;
            }

            long[][] matrix = new long[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = new long[row + 1];

                for (int col = 0; col <= row; col++)
                {
                    if (col == 0)
                    {
                        matrix[row][col] = 1;
                    }
                    else if (col == row)
                    {
                        matrix[row][col] = 1;
                    }
                    else
                    {
                        matrix[row][col] = matrix[row - 1][col] + matrix[row - 1][col - 1];
                    }
                }
            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
