namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int heroCount = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < heroCount; i++)
            {
                string name = Console.ReadLine();
                string heroTypeInput = Console.ReadLine();
                string heroType = heroTypeInput.First().ToString().ToUpper() + heroTypeInput.Substring(1);


                BaseHero hero = DynamicFactory.CreateHero(name, heroType);

                if (hero != null)
                {
                    heroes.Add(hero);
                    Console.WriteLine(hero.CastAbility());
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }

            }

            int bossPower = int.Parse(Console.ReadLine());

            int heroesPower = heroes.Sum(h => h.Power);

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}