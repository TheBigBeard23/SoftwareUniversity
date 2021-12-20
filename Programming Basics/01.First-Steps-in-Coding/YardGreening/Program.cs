using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double square = double.Parse(Console.ReadLine());
            double sum = square * 7.61;
            double discount = 0.18 * sum;
            double totalSum = sum - discount;
            Console.WriteLine($"The final price is: {totalSum:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");



        }
    }
}
