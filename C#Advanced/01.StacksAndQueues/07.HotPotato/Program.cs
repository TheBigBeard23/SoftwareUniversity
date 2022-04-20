using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>(Console.ReadLine().Split());
            int count = int.Parse(Console.ReadLine());

            while (players.Count > 1)
            {
                Play(players, count);
            }

            Console.WriteLine($"Last is {players.Dequeue()}");

        }

        static void Play(Queue<string> players, int count)
        {

            for (int i = 1; i < count; i++)
            {
                players.Enqueue(players.Dequeue());
            }

            Console.WriteLine($"Removed {players.Dequeue()}");
        }
    }
}
