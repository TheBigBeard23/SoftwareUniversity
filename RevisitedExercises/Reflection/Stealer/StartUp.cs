namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string result = Spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
