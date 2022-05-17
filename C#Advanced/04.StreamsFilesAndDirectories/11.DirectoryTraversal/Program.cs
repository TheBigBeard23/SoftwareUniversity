using System;

namespace _11.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = DirectoryTraversal.TraverseDirectory(@"C:\Users\Public\Desktop\");
            DirectoryTraversal.WriteReportToDesktop(text, "report");
        }
    }
}
