namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string result = Spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
