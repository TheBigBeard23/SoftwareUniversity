using System;

namespace MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            if (firstNum > 10 || secondNum > 10)
            {
                Console.WriteLine($"{firstNum} X {secondNum} = {(firstNum * secondNum)}");
            }
            else if (secondNum < 10 || 10 > firstNum)
            {
                for (int i = secondNum; i <= 10; i++)
                {

                    Console.WriteLine($"{firstNum} X {i} = {(firstNum * i)}");
                }
            }
        }
    }
}
