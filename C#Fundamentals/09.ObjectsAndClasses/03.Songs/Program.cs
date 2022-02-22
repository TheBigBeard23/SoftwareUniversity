using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split('_',StringSplitOptions.RemoveEmptyEntries);
                string type = input[0];
                string name = input[1];
                string time = input[2];

                songs.Add(new Song(type, name, time));
            }

            string command = Console.ReadLine();

            if (command == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songs.Where(x=>x.Type==command))
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }

    public class Song
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public Song(string type,string name,string time)
        {
            Type = type;
            Name = name;
            Time = time;

        }

    }
}
