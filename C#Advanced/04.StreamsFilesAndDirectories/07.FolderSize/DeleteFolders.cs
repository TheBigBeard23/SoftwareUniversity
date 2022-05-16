using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _07.FolderSize
{
    class DeleteFolders
    {
        public static void Delete(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);

            foreach (var file in files)
            {
                File.Delete(file);
            }

            var directories = Directory.GetDirectories(folderPath);

            foreach (var directory in directories)
            {
                Delete(directory);
                Directory.Delete(directory);
            }

        }
    }
}
