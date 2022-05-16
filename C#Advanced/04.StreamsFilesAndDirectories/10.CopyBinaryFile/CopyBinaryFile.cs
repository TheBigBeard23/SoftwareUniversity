using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _10.CopyBinaryFile
{
    public class CopyBinaryFile
    {
        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream reader = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];

                using (FileStream writer = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    for (int i = 0; i < reader.Length / buffer.Length; i++)
                    {
                        reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer);
                    }
                }
            }
        }

    }
}


