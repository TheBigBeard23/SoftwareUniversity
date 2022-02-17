using System;

namespace CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int year = centuries * 100;
            int days = (int)(year * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
            Console.WriteLine($"{centuries} centuries = {year} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
