using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];
                }
                sum += matrix[row, row];
            }

            Console.WriteLine(sum);

        }
    }
}
