using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int input = int.Parse(Console.ReadLine());

            while (input < number)
            {
                input += int.Parse(Console.ReadLine());
            }
            Console.WriteLine(input);
        }
    }
}
