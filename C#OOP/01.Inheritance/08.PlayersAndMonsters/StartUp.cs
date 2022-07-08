using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var darkKnight = new DarkKnight("Jose", 33);

            Console.WriteLine(darkKnight);
        }
    }
}
