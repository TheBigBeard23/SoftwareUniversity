using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<double> list = new List<double>();

            for (int i = 0; i < count; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double value = double.Parse(Console.ReadLine());

            Console.WriteLine(Box.Compare<double>(list, value));
        }
    }
}
