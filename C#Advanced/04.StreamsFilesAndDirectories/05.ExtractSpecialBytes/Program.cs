using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.ExtractSpecialBytes
{
    class Program
    {
        static void Main(string[] args)
        {
        
            byte[] fileBytes = File.ReadAllBytes("../../../example.png");

            List<string> bytesList = File.ReadAllText("../../../bytes.txt")
                                         .Split(Environment.NewLine)
                                         .ToList();
            
            using(StreamWriter writer = new StreamWriter("../../../output.bin"))
            {
                foreach (var item in fileBytes)
                {
                    if (bytesList.Contains(item.ToString()))
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
            
        
        }
    }
}
