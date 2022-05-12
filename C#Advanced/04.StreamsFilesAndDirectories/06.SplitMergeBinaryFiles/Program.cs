using System;

namespace _06.SplitMergeBinaryFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            SplitMergeBinaryFile.SplitBinaryFile("../../../example.png", "../../../part-1.bin", "../../../part-2.bin");
            SplitMergeBinaryFile.MergeBinaryFiles("../../../part-1.bin", "../../../part-2.bin", "../../../example-joined.png");
        }
    }
}
