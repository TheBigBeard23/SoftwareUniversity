using System;
using System.Collections;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack numbersAndOperations = new Stack(Console.ReadLine().Split());
            int sum = 0;

            while (numbersAndOperations.Count>1)
            {
                int number = int.Parse(numbersAndOperations.Pop().ToString());
                string operation = numbersAndOperations.Pop().ToString();

                switch (operation)
                {
                    case "+":
                        sum += number;
                        break;

                    case "-":
                        sum -= number;
                        break;

                }
            }
            sum += int.Parse(numbersAndOperations.Pop().ToString());

            Console.WriteLine(sum);
        }
    }
}
