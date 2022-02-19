using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = Add(firstNumber, secondNumber);
            result = Subtract(result, thirdNumber);

            Console.WriteLine(result);

        }

        static int Add(int a,int b)
        {
            return a + b;
        }
        static int Subtract(int a,int b)
        {
            return a - b;
        }
    }
}
