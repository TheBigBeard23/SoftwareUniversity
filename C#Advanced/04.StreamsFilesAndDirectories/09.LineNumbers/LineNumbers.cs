using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _09.LineNumbers
{
    public class LineNumbers
    {
        public static void ProcessLines(string inputFilePath,string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                string crnLine = lines[i];
                MatchCollection marks = Regex.Matches(crnLine, "[-,.?!'\":]");
                MatchCollection letters = Regex.Matches(crnLine, "[A-z]");

                sb.AppendLine($"Line {i + 1}: {crnLine} ({letters.Count})({marks.Count})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
