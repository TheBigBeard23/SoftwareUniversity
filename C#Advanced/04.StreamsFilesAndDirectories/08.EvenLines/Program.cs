using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _08.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int counter = 1;

                while (line != null)
                {
                    if (counter % 2 == 1)
                    {
                        line = Regex.Replace(line, "[-,.!?]", "@");

                        var newLine = line.Split()
                                          .Reverse()
                                          .ToArray();

                        Console.WriteLine(string.Join(" ", newLine));
                    }

                    line = reader.ReadLine();
                    counter++;
                }
            }
        }
    }
}
