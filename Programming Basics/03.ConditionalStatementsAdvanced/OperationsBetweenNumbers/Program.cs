using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double result = 0; 
            string oddOrEven = "";
            if (n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            switch (operation)
            {
                case '+':
                    result = n1 + n2;
                    if (result % 2 == 0)
                    {
                        oddOrEven = "even";
                    }
                    else
                    {
                        oddOrEven = "odd";
                    }
                    Console.WriteLine($"{n1} + {n2} = {result} - {oddOrEven}");
                    break;
                case '-':
                    result = n1 - n2;
                    if (result % 2 == 0)
                    {
                        oddOrEven = "even";
                    }
                    else
                    {
                        oddOrEven = "odd";
                    }
                    Console.WriteLine($"{n1} - {n2} = {result} - {oddOrEven}");
                    break;
                case '/':
                   
                    result = n1 / n2;
                    if (result % 2 == 0)
                    {
                        oddOrEven = "even";
                    }
                    else
                    {
                        oddOrEven = "odd";
                    }
                    Console.WriteLine($"{n1} / {n2} = {result} - {oddOrEven}");
                    break;
                case '*':
                    result = n1 * n2;
                    if (result % 2 == 0)
                    {
                        oddOrEven = "even";
                    }
                    else
                    {
                        oddOrEven = "odd";
                    }
                    Console.WriteLine($"{n1} * {n2} = {result} - {oddOrEven}");
                    break;
                case '%':
                    result = n1 % n2;
                    if (result % 2 == 0)
                    {
                        oddOrEven = "even";
                    }
                    else
                    {
                        oddOrEven = "odd";
                    }
                    Console.WriteLine($"{n1} % {n2} = {result} - {oddOrEven}");
                    break;

                default:
                    break;
            }
        }
    }
}
