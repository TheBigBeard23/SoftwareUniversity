using System;
using System.IO;

namespace _07.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            double fileSize = FolderSize.GetFolderSize(@"../../../TestFolder");

            File.WriteAllText("../../../output.txt", fileSize.ToString());
        }
    }
}
