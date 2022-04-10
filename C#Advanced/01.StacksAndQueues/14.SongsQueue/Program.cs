using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));
            string input = Console.ReadLine();

            while (songs.Count > 0)
            {

                if (input.Contains("Add"))
                {
                    string name = input.Substring(4, input.Length - 4);

                    if (songs.Contains(name))
                    {
                        Console.WriteLine($"{name} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(name);
                    }
                }
                else if (input.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else
                {
                    songs.Dequeue();
                }

                input = Console.ReadLine(); 
            }
            Console.WriteLine("No more songs!");
        }
    }
}
