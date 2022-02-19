using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Calculate(operation, firstNumber, secondNumber);
        }
        static void Calculate(string operation,int firstNumber,int secondNumber)
        {
            int result = 0;

            switch (operation)
            {
                case "add":
                    result = firstNumber + secondNumber;
                    break;
                case "multiply":
                    result = firstNumber * secondNumber;
                    break;
                case "subtract":
                    result = firstNumber - secondNumber;
                    break;
                case "divide":
                    result = firstNumber / secondNumber;
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
