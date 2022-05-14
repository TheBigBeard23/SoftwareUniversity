using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace _06.SplitMergeBinaryFiles
{
    class SplitMergeBinaryFile
    { 
        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] sourceFileBytes = File.ReadAllBytes(sourceFilePath);
            int firstFileLenght = 0;

            using (StreamWriter writer = new StreamWriter(partOneFilePath))
            {
                if (sourceFileBytes.Length % 2 == 1)
                {
                    firstFileLenght = sourceFileBytes.Length / 2 + 1;
                }
                else
                {
                    firstFileLenght = sourceFileBytes.Length / 2;
                }

                for (int i = 0; i < firstFileLenght; i++)
                {
                    writer.Write(sourceFileBytes[i]);
                }
            }
            using (StreamWriter writer = new StreamWriter(partTwoFilePath))
            {
                for (int i = firstFileLenght; i < sourceFileBytes.Length; i++)
                {
                    writer.Write(sourceFileBytes[i]);
                }
            }

        }
        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream writerStream = new FileStream(joinedFilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (FileStream readerStream = new FileStream(partOneFilePath, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    readerStream.CopyTo(writerStream);
                }
                using (FileStream readerStream = new FileStream(partTwoFilePath, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    readerStream.CopyTo(writerStream);
                }

            }
        }
    }
}
