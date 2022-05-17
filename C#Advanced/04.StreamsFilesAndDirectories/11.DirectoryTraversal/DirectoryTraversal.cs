using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _11.DirectoryTraversal
{
    public class DirectoryTraversal
    {
        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, Dictionary<string, double>> extensionsFilesSize = new Dictionary<string, Dictionary<string, double>>();
            StringBuilder sb = new StringBuilder();

            var files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                string extension = fileInfo.Extension;
                string name = fileInfo.Name;
                double size = fileInfo.Length / 1024.0;

                if (!extensionsFilesSize.ContainsKey(extension))
                {
                    extensionsFilesSize[extension] = new Dictionary<string, double>();
                }
                extensionsFilesSize[extension].Add(name, size);

            }

            foreach (var extension in extensionsFilesSize.OrderByDescending(x => x.Value.Count)
                                                         .ThenBy(x => x.Key))
            {
                sb.AppendLine($"{extension.Key}");

                foreach (var file in extension.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }

            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent,string reportFileName)
        {
            using (FileStream stream = new FileStream(@$"C:\Users\Bones\Desktop\{reportFileName}.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] bytes = Encoding.ASCII.GetBytes(textContent);
                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
