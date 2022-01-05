using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            for (int i = 1111; i <= 9999; i++)
            {
                int counter = 0;

                for (int k = 0; k < i.ToString().Length; k++)
                {
                    int currentNum = int.Parse(i.ToString()[k].ToString());
                    if (currentNum != 0 && number % currentNum == 0)
                    {
                        counter++;
                    }
                }

                if (counter == 4)
                {
                    Console.Write(i+" ");
                }
            }
        }
    }
}
