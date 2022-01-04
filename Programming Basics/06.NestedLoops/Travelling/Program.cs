using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
               string destination = Console.ReadLine();

                if (destination == "End")
                {
                    break;
                }

                double price = double.Parse(Console.ReadLine()), savings = 0;

                while (price>savings)
                { 

                    savings += double.Parse(Console.ReadLine());

                }
                
                Console.WriteLine($"Going to {destination}!");

            }

        }
    }
}
