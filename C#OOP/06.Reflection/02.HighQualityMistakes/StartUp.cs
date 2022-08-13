using Stealer;
using System;

namespace HighQualityMistakes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.AnalyzeAccessModifiers("Hacker"));
        }
    }
}
