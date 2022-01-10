using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            char[] charArray = username.ToCharArray();
            Array.Reverse(charArray);
            string password = String.Join("",charArray);

            string input = Console.ReadLine();
            int counter = 0;

            while (input!=password)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }

            Console.WriteLine($"User {username} logged in.");
        }
    }
}
