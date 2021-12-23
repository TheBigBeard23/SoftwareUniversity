using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
      
            int seats = rows * columns;
            double price = 0;
  
            switch (type)
            {
                case "Premiere":
                    price = 12;
                    break;
                case "Normal":
                    price = 7.50;
                    break;
                case "Discount":
                    price = 5;
                    break;

            }
            double total = price * seats;

            Console.WriteLine($"{total:f2} leva");
        }
    }
}
