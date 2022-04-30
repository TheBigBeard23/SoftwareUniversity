using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            HashSet<string> carsNumber = new HashSet<string>(); 

            while (input[0] != "END")
            {
                if (input[0] == "IN")
                {
                    carsNumber.Add(input[1]);
                }
                else
                {
                    carsNumber.Remove(input[1]);
                }

                input = Console.ReadLine().Split(", ");
            }

            if (carsNumber.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine,carsNumber));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
