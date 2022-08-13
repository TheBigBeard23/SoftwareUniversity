using System;

namespace AuthorProblem
{
    [Author("Vlad")]
    public class StartUp
    {
        [Author("Jon")]
        public static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
