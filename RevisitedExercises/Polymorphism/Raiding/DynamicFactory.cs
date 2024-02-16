namespace Raiding
{
    public static class DynamicFactory
    {
        public static BaseHero CreateHero(string name, string type)
        {
            Type heroType = Type.GetType("Raiding." + type);

            if (heroType != null && typeof(BaseHero).IsAssignableFrom(heroType))
            {
                BaseHero hero = (BaseHero)Activator.CreateInstance(heroType, name, 1);
                hero.Name = name;

                return hero;
            }
            return null;
        }
    }
}