using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int maxNum = -2147483648;

            while ((input = Console.ReadLine())!="Stop")
            {
                int currentNum = int.Parse(input);
                if(maxNum< currentNum)
                {
                    maxNum = currentNum;
                }
            }
            Console.WriteLine(maxNum);
        }
    }
}
