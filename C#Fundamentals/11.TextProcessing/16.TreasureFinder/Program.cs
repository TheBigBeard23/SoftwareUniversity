using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> keys = Console.ReadLine().Split()
                                               .Select(int.Parse)
                                               .ToList();
            
            string input = Console.ReadLine();

            while (input!="find")
            {
                string data = DecryptMessage(input, keys);
                PrintMessage(data);

                input = Console.ReadLine();
            }
        }
        static string DecryptMessage(string text,List<int> keys)
        {
            string result = string.Empty;
            int keyIndexer = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (keyIndexer == keys.Count)
                {
                    keyIndexer = 0;
                }

                result += (char)(text[i] - keys[keyIndexer]);

                keyIndexer++;
            }

            return result;
        }
        static void PrintMessage(string data)
        {
            string treasureType = string.Empty;
            string coordinates = string.Empty;

            int index = data.IndexOf('&') + 1;

            while (data[index]!='&')
            {
                treasureType += data[index];
                index++;
            }

            index = data.IndexOf('<') + 1;

            while (data[index] != '>')
            {
                coordinates += data[index];
                index++;
            }

            Console.WriteLine($"Found {treasureType} at {coordinates}");
        }
    }
}
