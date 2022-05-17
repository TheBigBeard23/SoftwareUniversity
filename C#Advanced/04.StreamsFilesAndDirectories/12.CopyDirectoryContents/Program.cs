using System;

namespace _12.CopyDirectoryContents
{
    class Program
    {
        static void Main(string[] args)
        {
            //CopyDirectory.CheckDirectoryExist(@"C:\Users\Bones\Desktop\Test2");
            CopyDirectory.CopyAllFiles(@"C:\Users\Bones\Desktop\Test", @"C:\Users\Bones\Desktop\Test2");
        }
    }
}
