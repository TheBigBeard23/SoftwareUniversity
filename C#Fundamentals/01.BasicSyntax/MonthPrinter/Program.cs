using System;

namespace MonthPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = new string[] 
            { "", "January", "February", "March", "April", "May", 
              "June", "July", "August", "September", "Octomber", 
              "November", "December" };

            int number = int.Parse(Console.ReadLine());

            if (number > 12 || number < 1)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine(months[number]);
            }
        }
    }
}
