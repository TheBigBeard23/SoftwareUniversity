namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;
        public Warrior(string name, int power)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
