using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace _13.ZipAndExtract
{
    class ZipAndExtract
    {
        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (var archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(inputFilePath, Path.GetFileName(inputFilePath));
            }
        }
        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (var archive = ZipFile.OpenRead(zipArchiveFilePath))
            {
                foreach (var entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(outputFilePath, fileName));
                }
            }
        }
    }
}
