using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            double saveMoney = double.Parse(Console.ReadLine());
            int spendCount = 0;
            int days = 0;
            while (saveMoney<tripPrice)
            {
                string command = Console.ReadLine();
                days++;
                switch (command)
                {
                    case "spend":
                        saveMoney -= double.Parse(Console.ReadLine());
                        spendCount++;
                        if (saveMoney < 0) 
                        { 
                            saveMoney = 0; 
                        }
                        break;
                    case "save":
                        saveMoney += double.Parse(Console.ReadLine());
                        break;
                    default:
                        break;
                }

                if (spendCount >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine("5");
                }
            }
            if(tripPrice<=saveMoney)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }

        }
    }
}
