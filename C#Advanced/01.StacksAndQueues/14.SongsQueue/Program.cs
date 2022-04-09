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
            //string[] input = Console.ReadLine().Split().ToArray();
            string input = Console.ReadLine();
            while (songs.Count > 0)
            {
                //string command = input[0];

                if (input.Contains("Add"))
                {
                    var data = input.Split().ToArray();
                    data[0] = "";
                    string name = string.Join(" ", data.Where(x => x != ""));
                    //string name = input.Substring(4, input.Length - 4);

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
                //switch (command)
                //{
                //    case "Play":
                //        songs.Dequeue();
                //        break;

                //    case "Add":
                //        input[0] = "";
                //        string name = string.Join(" ", input.Where(x => x != ""));

                //        if (songs.Contains(name))
                //        {
                //            Console.WriteLine($"{name} is already contained!");
                //        }
                //        else
                //        {
                //            songs.Enqueue(name);
                //        }
                //        break;

                //    case "Show":
                //        Console.WriteLine(string.Join(", ", songs));
                //        break;
                //}

                input = Console.ReadLine(); 
            }
            Console.WriteLine("No more songs!");
        }
    }
}
