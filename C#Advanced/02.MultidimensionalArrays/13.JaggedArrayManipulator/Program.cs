using System;
using System.Linq;

namespace _13.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray();

            }

            for (int row = 0; row < rows; row++)
            {

                if (row + 1 < rows)
                {
                    if (matrix[row].Length == matrix[row + 1].Length)
                    {
                        matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                        matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                    }
                    else
                    {
                        matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                        matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                    }
                }

            }

            string[] data = Console.ReadLine().Split();
            string command = data[0];

            while (command!="End")
            {
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int value = int.Parse(data[3]);

                if (row >= 0 && col >= 0 &&
                    row < rows && col < matrix[row].Length)
                {
                    switch (command)
                    {
                        case "Add":
                            matrix[row][col] += value;
                            break;

                        case "Subtract":
                            matrix[row][col] -= value;
                            break;
                    }
                }

                data = Console.ReadLine().Split();
                command = data[0];

            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }

        }
    }
}
