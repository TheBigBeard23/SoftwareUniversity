using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numsLenght = nums.Length;

            while (numsLenght > 1)
            {
                int[] condensed = new int[nums.Length - 1];

                for (int i = 0; i < numsLenght - 1; i++)
                {
                    condensed[i] = nums[i] + nums[i + 1];
                }

                nums = new int[numsLenght - 1];

                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = condensed[i];
                }
                numsLenght--;
            }

            Console.WriteLine(nums[0]);
        }
    }
}
