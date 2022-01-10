using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int factorial = 0;
            string numberAsString = number.ToString();

            for (int i = 0; i < numberAsString.Length; i++)
            {
                int currentNum = int.Parse(numberAsString[i].ToString());
                int currentFactorial = 1;

                for (int k = 1; k <= currentNum; k++)
                {
                    currentFactorial *= k;
                }
                factorial += currentFactorial;
                
            }

            if (factorial == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
