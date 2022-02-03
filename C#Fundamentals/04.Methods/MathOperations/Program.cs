using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Calculate(firstNumber, operation, secondNumber);
        }

        static void Calculate(int firstNumber, char operation, int secondNumber)
        {
            int result = 0;

            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '/':
                    result = firstNumber / secondNumber;
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
