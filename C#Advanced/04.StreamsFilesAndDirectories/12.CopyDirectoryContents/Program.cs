using System;
using System.IO;

namespace _12.CopyDirectoryContents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter source path:");
            string sourcePath = Console.ReadLine();
            Console.WriteLine("Enter copy path:");
            string copyPath = Console.ReadLine();

            DirectoryInfo di = new DirectoryInfo(sourcePath);
            string name = di.Name;

            CopyDirectory.CheckDirectoryExist($@"{copyPath}\{name}");
            CopyDirectory.CopyAllFiles(sourcePath, copyPath);
        }
    }
}
