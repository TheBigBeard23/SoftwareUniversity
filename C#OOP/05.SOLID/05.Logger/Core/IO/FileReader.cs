using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID.Core.IO
{
    public class FileReader : IReader
    {
        private readonly string filePath;
        private readonly string[] fileLines;
        private int pointer;
        public FileReader(string filePath)
        {
            this.filePath = filePath;
            fileLines = File.ReadAllLines(filePath);
        }
        public string ReadLine()
        {
            return fileLines[pointer++];
        }
    }
}
