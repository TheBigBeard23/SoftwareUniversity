using System;
using System.Collections.Generic;

namespace _10.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            var firstTuple = new Tuple<string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2]);

            string[] secondInput = Console.ReadLine().Split();
            var secondTuple = new Tuple<string, double>(secondInput[0], double.Parse(secondInput[1]));

            string[] thirdInput = Console.ReadLine().Split();
            var thirdTuple = new Tuple<int, double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));

            Console.WriteLine(firstTuple.ToString()); 
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());

        }
    }
}
