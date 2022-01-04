using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = string.Empty;
            int price = 0;
            int savings = 0;
            string command = string.Empty;

            while (true)
            {
                destination = Console.ReadLine();

                if (destination == "End")
                {
                    break;
                }

                price = int.Parse(Console.ReadLine());

                while (price>savings)
                {
                    command = Console.ReadLine();

                    if (command == "End")
                    {
                        return;
                    }

                    savings += int.Parse(command);

                }
                
                Console.WriteLine($"Going to {destination}!");

                savings = 0;
            }



        }
    }
}
