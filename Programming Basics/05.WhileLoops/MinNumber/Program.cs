using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int minNum = 2147483647;

            while ((input = Console.ReadLine()) != "Stop")
            {
                int currentNum = int.Parse(input);
                if (minNum > currentNum)
                {
                    minNum = currentNum;
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
