using System;

namespace _11.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            var firstTuple = new Threeuple<string, string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2], firstInput[3]);

            string[] secondInput = Console.ReadLine().Split();
            var secondTuple = new Threeuple<string, string, bool>(secondInput[0],secondInput[1], secondInput[2] == "drunk" ? true : false);

            string[] thirdInput = Console.ReadLine().Split();
            var thirdTuple = new Threeuple<string, double, string>(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);

            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
