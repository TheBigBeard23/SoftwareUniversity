using System;

namespace _13.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipAndExtract.ZipFileToArchive("../../../mario.png", "../../../archive.zip");
            ZipAndExtract.ExtractFileFromArchive("../../../archive.zip", "picture.png", "../../../");
        }
    }
}
