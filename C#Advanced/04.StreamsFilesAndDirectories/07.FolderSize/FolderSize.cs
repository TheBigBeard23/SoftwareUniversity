using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _07.FolderSize
{
    class FolderSize
    {
        public static double GetFolderSize(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);

            double fileSizes = 0;

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);
                fileSizes += file.Length;
            }

            var directories = Directory.GetDirectories(folderPath);

            foreach (var directory in directories)
            {
                
                fileSizes += GetFolderSize(directory);
            }

            return fileSizes;

        }
    }
}
