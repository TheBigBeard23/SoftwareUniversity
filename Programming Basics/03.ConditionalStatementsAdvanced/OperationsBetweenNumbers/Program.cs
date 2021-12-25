using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double result = 0; 
            string oddOrEven = "";
           
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
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }
                    result = n1 / n2;
                    
                    Console.WriteLine($"{n1} / {n2} = {result}");
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
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }
                    result = n1 % n2;
                  
                    Console.WriteLine($"{n1} % {n2} = {result}");
                    break;

                default:
                    break;
            }
        }
    }
}
