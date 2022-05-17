using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _12.CopyDirectoryContents
{
    class CopyDirectory
    {
        public static void CheckDirectoryExist(string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
        }
        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo di = new DirectoryInfo(inputPath);

            string name = di.Name;
            string path = @$"{outputPath}\{name}";

            Directory.CreateDirectory(path);

            var files = Directory.GetFiles(inputPath);

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);
                string fileName = file.Name;

                using (FileStream stream = new FileStream(@$"{path}\{fileName}", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] bytes = File.ReadAllBytes(filePath);
                    stream.Write(bytes);
                }
            }

            var directories = Directory.GetDirectories(inputPath);

            foreach (var directory in directories)
            {
                CopyAllFiles(directory, path);
            }

        }

    }
}
