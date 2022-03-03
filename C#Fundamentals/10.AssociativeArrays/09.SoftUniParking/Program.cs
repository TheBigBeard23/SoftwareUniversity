using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkRegister = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            while (n>0)
            {
                string[] input = Console.ReadLine()
                                          .Split()
                                          .ToArray();

                string command = input[0];
                string username = input[1];

                switch (command)
                {
                    case "register":

                        
                        string licensePlateNumber = input[2];

                        if (parkRegister.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                        }
                        else
                        {
                            parkRegister[username] = licensePlateNumber;
                            Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                        }

                        break;

                    case "unregister":

                        if (parkRegister.ContainsKey(username))
                        {
                            parkRegister.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        break;
                }
                n--;
            }

            foreach (var user in parkRegister)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
