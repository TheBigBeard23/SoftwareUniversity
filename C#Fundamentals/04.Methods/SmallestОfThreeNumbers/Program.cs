using System;
using System.Linq;

namespace SmallestОfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSmallestNumber(firstNumber,secondNumber,thirdNumber));

        }
        static int GetSmallestNumber(int firstNumber,int secondNumber,int thirdNumber)
        {
            int[] numbers = new int[] { firstNumber, secondNumber, thirdNumber };

            return numbers.OrderBy(x => x).FirstOrDefault();
        }

    }
}
