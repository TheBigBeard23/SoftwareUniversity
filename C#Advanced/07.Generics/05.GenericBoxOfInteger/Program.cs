using System;

namespace GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new Box<int>(int.Parse(Console.ReadLine())).ToString());
            }
        }
    }
}
